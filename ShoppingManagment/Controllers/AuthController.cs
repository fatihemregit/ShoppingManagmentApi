using AutoMapper;
using Entity.Auth;
using Entity.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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


		//yeni kullanıcı ve token işlemleri
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
		private string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using (RandomNumberGenerator random = RandomNumberGenerator.Create())
			{
				random.GetBytes(number);
				return Convert.ToBase64String(number);
			}
		}
		//kullanıcı kaydı oluşturma
		[HttpPost("/register")]
		public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest userRequest)
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
			IdentityResult createUserResult = await _userManager.CreateAsync(user,userRequest.Password);
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
		
		public void CreateError(IEnumerable<IdentityError> Errors)
		{
			string errorMessage = "kullanıcı kaydı başarısız";
			foreach (IdentityError e in Errors)
			{
				errorMessage += $"\n{e}";
			}
			throw new IdentityException(errorMessage);
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


}
