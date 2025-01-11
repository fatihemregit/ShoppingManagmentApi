using AutoMapper;
using Entity.Auth;
using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AuthController(IConfiguration configuration, UserManager<AppUser> userManager, IMapper mapper)
		{
			_configuration = configuration;
			_userManager = userManager;
			_mapper = mapper;
		}


		//yeni kullanıcı kaydı ve token işlemleri başlangıç

		//access token oluşturma
		private string CreateAccessToken(DateTime accessTokenExpiration)
		{
			//securityKey i oluşturuyoruz
			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwt:securityKey").Value));
			//Şifrelenmiş kimliği oluşturuyoruz.
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			JwtSecurityToken securityToken = new JwtSecurityToken(
				issuer: _configuration.GetSection("jwt:issuer").Value,
				audience: _configuration.GetSection("jwt:audience").Value,
				expires: accessTokenExpiration,
				notBefore: DateTime.Now,
				signingCredentials: signingCredentials
				);
			JwtSecurityTokenHandler securityTokenHandler = new JwtSecurityTokenHandler();
			string accessToken = securityTokenHandler.WriteToken(securityToken);
			return accessToken;
		}
		//Refresh token oluşturma
		private string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using (RandomNumberGenerator random = RandomNumberGenerator.Create())
			{
				random.GetBytes(number);
				return Convert.ToBase64String(number);
			}
		}
		//yeni kullanıcı kaydı oluşturma
		[HttpPost("/register")]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
		{
			//user nesnesini oluşturup,UserName,Email alanlarını dolduruyoruz
			AppUser user = _mapper.Map<AppUser>(userRequest);
			//tokenlerin bitiş tarihlerini tanımlıyoruz	
			DateTime refreshTokenEndDate = DateTime.Now.AddDays(7);
			DateTime accessTokenEndDate = DateTime.Now.AddMinutes(15);
			//refreshToken ı tanımlıyoruz
			string refreshToken = CreateRefreshToken();
			//user nesnesinin refreshToken alanını dolduruyoruz
			user.RefreshToken = refreshToken;
			//user nesnesinin refreshTokenEndDate alanını dolduruyoruz
			user.RefreshTokenEndDate = refreshTokenEndDate;
			//yeni kullanıcıyı veritabanına kaydediyoruz
			IdentityResult createUserResult = await _userManager.CreateAsync(user, userRequest.Password);
			if (createUserResult.Succeeded)
			{
				//kullanıcı kaydı başarılı accessToken üreteceğiz
				TokenModel tokenModel = new TokenModel();
				tokenModel.AccessToken = CreateAccessToken(accessTokenEndDate);
				tokenModel.AcessTokenExpiration = accessTokenEndDate;
				tokenModel.RefreshToken = refreshToken;
				tokenModel.RefreshTokenExpiration = refreshTokenEndDate;
				return Ok(tokenModel);
			}
			else
			{
				//kullanıcı kaydı başarısız hataları döneceğiz
				CreateError(createUserResult.Errors);
				return Ok();
			}
		}

		//kullanıcı kaydı sırasında hata varsa basma
		public void CreateError(IEnumerable<IdentityError> Errors)
		{
			string errorMessage = "kullanıcı kaydı başarısız";
			foreach (IdentityError e in Errors)
			{
				errorMessage += $"\n{e}";
			}
			throw new IdentityException(errorMessage);
		}




		//yeni kullanıcı kaydı ve token işlemleri bitiş
		//hali hazırda olan kullanıcının RefreshToken ile AcessToken ını yenilemesi başlangıç

		private  async Task<bool> checkRefreshToken(string RefreshToken)
		{
			AppUser? foundUserwithRefershToken = await _userManager.Users.Where(u => u.RefreshToken == RefreshToken).SingleOrDefaultAsync();
			if(foundUserwithRefershToken is not null)
			{
				//veritabanında RefreshToken ile alakalı user var
				//refresh token ın son kullanma tarihini kontrol edelim
				if (foundUserwithRefershToken.RefreshTokenEndDate < DateTime.Now)
				{
					return false;
					//throwAError("Refresh token süresi dolmuş.lütfen yeniden login olun");
				}
				return true;
			}
			else
			{
				return false;
			}
		}

		private void throwAError(string message)
		{
			throw new IdentityException(message);
		}
		[HttpPost("newAccessToken")]
		public async Task<IActionResult> newAccessToken([FromBody] string RefreshToken)
		{
			//refresh Token ını veritabanında kontrol edelim(son kullanma tarihi,böyle bir token var mı yok mu)
			if (!(await checkRefreshToken(RefreshToken)))
			{
				//refresh token hatalı
				throwAError("refresh token hatalı");
			}
			//veritabanında sıkıntı yok
			//yeni token oluşturalım
			DateTime accessTokenExpiration = DateTime.Now.AddMinutes(15);
			string accessToken = CreateAccessToken(accessTokenExpiration);
			NewAccessTokenResponse response = new NewAccessTokenResponse();
			response.AcessTokenExpiration = accessTokenExpiration;
			response.AccessToken = accessToken;
			//kara liste(daha sonra yapılacak)
			return Ok(response);
		}
		//hali hazırda olan kullanıcının RefreshToken ile AcessToken ını yenilemesi bitiş

		//login işlemi(kullanıcının refresh tokenı ve AcessTokenı bitmiş)
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginUserRequest request)
		{
			//bu bilgilere göre kullanıcının olup olmadığını kontrol edelim
			AppUser? foundUser = await _userManager.FindByNameAsync(request.UserName);
			if (foundUser is null)
			{
				throwAError("kulllanıcı bilgileri hatalı");
				return Ok();
			}
			//bu bilgilere göre kullanıcı var
			if (await _userManager.CheckPasswordAsync(foundUser,request.Password))
			{
				TokenModel tokenModel = new TokenModel();
				//kullanıcı parolası doğru  refresh token ve AcessToken üretelim
				//Refresh tokenı check edelim
				if (!(await checkRefreshToken(foundUser.RefreshToken)))
				{
					//refresh token bitmiş yeni bir refresh token oluşturalım
					foundUser.RefreshToken = CreateRefreshToken();
					foundUser.RefreshTokenEndDate = DateTime.Now.AddDays(7);
					await _userManager.UpdateAsync(foundUser);
					await _userManager.UpdateSecurityStampAsync(foundUser);
				}
				//refresh tokenı atayalım
				tokenModel.RefreshToken = foundUser.RefreshToken;
				tokenModel.RefreshTokenExpiration = (DateTime)foundUser.RefreshTokenEndDate;
				//access token oluşturalım
				DateTime accessTokenExpiration = DateTime.Now.AddMinutes(15);
				tokenModel.AccessToken = CreateAccessToken(accessTokenExpiration);
				tokenModel.AcessTokenExpiration = accessTokenExpiration;
				return Ok(tokenModel);
			}
			else
			{
				//kullanıcı parolası yanlış hata fırlatalım
				throwAError("kulllanıcı bilgileri hatalı");
				return Ok();
			}



		}


	}

	public class TokenModel
	{
		public string AccessToken { get; set; }
		public DateTime AcessTokenExpiration { get; set; }
		public string RefreshToken { get; set; }
		public DateTime RefreshTokenExpiration { get; set; }
	}

	public class CreateUserRequest
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}

	public class NewAccessTokenResponse
	{
		public string AccessToken { get; set; }
		public DateTime AcessTokenExpiration { get; set; }
	}

	public class LoginUserRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }

	}

}
