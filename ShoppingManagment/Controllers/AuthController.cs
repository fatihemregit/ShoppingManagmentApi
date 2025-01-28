using AutoMapper;
using Business.Abstracts.Auth;
using Entity.Auth;
using Entity.IAuthService;
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
using Entity.AuthController;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;

		private readonly IAuthService _authService;

		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;

		public AuthController(IConfiguration configuration, UserManager<AppUser> userManager, IMapper mapper, IAuthService authService)
		{
			_configuration = configuration;
			_userManager = userManager;
			_mapper = mapper;
			_authService = authService;
		}


		/*
		 fterm:Hs@3n9#@LV
		 Saturate6417:u%cH5AGCLVbXm4KPbkvt
		 Customary3029:anHsPVAH8#5uD@@X@!9J
		 */

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
		[HttpPost("register")]
		public async Task<IActionResult> CreateUser([FromBody] AuthControllerCreateUserRequest userRequest)
		{
			IAuthServiceCreateUserResponse authServiceResponse = await _authService.createUser(_mapper.Map<IAuthServiceCreateUserRequest>(userRequest));
			AuthControllerCreateUserResponse authControllerResponse = _mapper.Map<AuthControllerCreateUserResponse>(authServiceResponse);
			return Ok(authControllerResponse);

		}

		//kullanıcı kaydı sırasında hata varsa basma
		private void CreateError(IEnumerable<IdentityError> Errors)
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
		public async Task<IActionResult> newAccessToken([FromBody] AuthControllerNewAccessTokenRequest request)
		{
			IAuthServiceNewAccessTokenResponse authServiceResponse = await _authService.newAccessToken(_mapper.Map<IAuthServiceNewAccessTokenRequest>(request));
			AuthControllerNewAccessTokenResponse authControllerResponse = _mapper.Map<AuthControllerNewAccessTokenResponse>(authServiceResponse);
			return Ok(authControllerResponse);
		}
		//hali hazırda olan kullanıcının RefreshToken ile AcessToken ını yenilemesi bitiş

		//login işlemi(kullanıcının refresh tokenı ve AcessTokenı bitmiş)
		[HttpPost("login")]
		public async Task<IActionResult> Login(AuthControllerLoginRequest request)
		{
			IAuthServiceLoginResponse authServiceResponse = await _authService.login(_mapper.Map<IAuthServiceLoginRequest>(request));
			AuthControllerLoginResponse authControllerResponse = _mapper.Map<AuthControllerLoginResponse>(authServiceResponse);
			return Ok(authControllerResponse);
		}

		[HttpPost("serviceTest")]
		public async Task<IActionResult> serviceTest([FromBody]IAuthServiceNewAccessTokenRequest request)
		{
			return Ok(await _authService.newAccessToken(request));
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

	public class NewAccessTokenRequest
	{
        public string RefreshToken { get; set; }

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
