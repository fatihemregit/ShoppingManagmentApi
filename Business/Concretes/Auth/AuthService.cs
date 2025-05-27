using AutoMapper;
using Business.Abstracts.Auth;
using Business.Utils.Functions;
using Entity.Auth;
using Entity.Exceptions;
using Entity.IAuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Auth
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;

		private readonly IConfiguration _configuration;
		private readonly IMapper _mapper;
		private readonly ILogger<AuthService> _logger;

		public AuthService(UserManager<AppUser> userManager, IConfiguration configuration, IMapper mapper, ILogger<AuthService> logger)
		{
			_userManager = userManager;
			_configuration = configuration;
			_mapper = mapper;
			_logger = logger;
		}

		//Create User functions start
		private string CreateRefreshToken()
		{
			byte[] number = new byte[32];
			using (RandomNumberGenerator random = RandomNumberGenerator.Create())
			{
				random.GetBytes(number);
				return Convert.ToBase64String(number);
			}
		}

		private string CreateAccessToken(DateTime accessTokenExpiration)
		{
			//DateTime accessTokenExpiration = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("accessTokenExpirationInMinute").Value));

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

		public async Task<IAuthServiceCreateUserResponse> createUser(IAuthServiceCreateUserRequest user)
		{
			if (HelpFullFunctions.nullCheckObjectProps(user))
			{
				_logger.LogDebug("user parametresi null olamaz");
				throw new BadRequestException("user parametresi null olamaz");
			}

			//yanlış hatırlamıyor isem app user nesnesi maplenerek kullanılamıyordu.bir bakmak lazım
			AppUser appUser = _mapper.Map<AppUser>(user);
			//tokenlerin bitiş tarihleri tanımlama
			DateTime accessTokenExpiration = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("jwt:accessTokenExpirationInMinute").Value));
			DateTime refreshTokenExpiration = DateTime.Now.AddDays(int.Parse(_configuration.GetSection("jwt:refreshTokenExpirationInDay").Value));
			//tokenları oluşturalım
			//acess Token Oluşturma
			string userAcessToken = CreateAccessToken(accessTokenExpiration);
			//refresh Token ı oluşturma
			string userrefreshToken = CreateRefreshToken();
			//refresh Token ı veritabanına kaydedelim
			appUser.RefreshToken = userrefreshToken;
			appUser.RefreshTokenEndDate = refreshTokenExpiration.ToUniversalTime();
			IdentityResult identityResult = await _userManager.CreateAsync(appUser, user.Password);
			if (identityResult.Succeeded)
			{
				IAuthServiceCreateUserResponse result = new IAuthServiceCreateUserResponse()
				{
					AccessToken = userAcessToken,
					AcessTokenExpiration = accessTokenExpiration.ToUniversalTime(),
					RefreshToken = userrefreshToken,
					RefreshTokenExpiration = refreshTokenExpiration.ToUniversalTime(),
				};
				_logger.LogInformation($"{user.UserName} adlı kullanıcının kullanıcı kaydı başarılı");
				return result;
			}
			else
			{
				_logger.LogDebug("kullanıcı kaydı başarısız");
				throw new IdentityException("kullanıcı kaydı başarısız");
			}
			
		}

		//Create User functions end


		//login user functions start
		public async Task<IAuthServiceLoginResponse> login(IAuthServiceLoginRequest user)
		{
			if (HelpFullFunctions.nullCheckObjectProps(user))
			{
				_logger.LogDebug("user parametresi null olamaz");
				throw new BadRequestException("user parametresi null olamaz");
			}

			//bu kod daha iyi nasıl yazılabilir?
			AppUser? foundUser = await _userManager.FindByNameAsync(user.UserName);
			if (foundUser is null)
			{
				//verilen kullanıcı adına göre kullanıcı yok hata dönelim
				_logger.LogDebug("kullanıcı bilgileri hatalı");
				throw new IdentityException("kullanıcı bilgileri hatalı");
			}

			if (await _userManager.CheckPasswordAsync(foundUser, user.Password))
			{
				//verilen kullanıcı bilgileri doğru.gerekli işlemleri yapalım
				//refresh Tokenın süresini check edelim ve süresi dolmuş ise yeni bir token oluşturup yeni bir süre atayalım
				//süresi dolmamış ise veritabanındaki tokenı dönelim
				if (foundUser.RefreshTokenEndDate < DateTime.Now.ToUniversalTime())
				{
					//süre dolmuş.yeni token ile alakalı işlemleri yapalım
					foundUser.RefreshToken = CreateRefreshToken();
					foundUser.RefreshTokenEndDate = DateTime.Now.ToUniversalTime().AddDays(int.Parse(_configuration.GetSection("jwt:refreshTokenExpirationInDay").Value));
					await _userManager.UpdateAsync(foundUser);
					await _userManager.UpdateSecurityStampAsync(foundUser);
				}
				else
				{
					//süre dolmamış(herhangi bir işlem yapmayacağız)(ama ne olur ne olmaz diye bu kısmı hazır bırakalım)
				}
				//acess token ı yenileyelim
				//bu accessTokenExpiration değişkenini çok sık kullanıyoruz.Acaba global e mi çeksek?
				DateTime accessTokenExpiration = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("jwt:accessTokenExpirationInMinute").Value));
				string newAcessToken = CreateAccessToken(accessTokenExpiration);
				IAuthServiceLoginResponse result = new IAuthServiceLoginResponse
				{
					AccessToken = newAcessToken,
					AcessTokenExpiration = accessTokenExpiration,
					RefreshToken = foundUser.RefreshToken,
					RefreshTokenExpiration = (DateTime)foundUser.RefreshTokenEndDate
				};
				_logger.LogInformation("kullanıcı girişi başarılı");
				return result;
			}
			else
			{
				//verilen parola yanlış hata dönelim
				_logger.LogDebug("kullanıcı bilgileri hatalı");
				throw new IdentityException("kullanıcı bilgileri hatalı");
			}

			//Acess Token



		}
		//login user functions end


		//newAccessToken functions start

		private async Task<bool> checkRefreshToken(string RefreshToken)
		{
			//bu fonksiyon böyle bir tokenın olup olmadığını(bir kullanıcıya tanımlanıp tanımlanmadığını),süresinin geçip geçmediğini kontrol eder
			AppUser? foundUserwithRefershToken = await _userManager.Users.Where(u => u.RefreshToken == RefreshToken).SingleOrDefaultAsync();
			if (foundUserwithRefershToken is not null)
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


		public async Task<IAuthServiceNewAccessTokenResponse> newAccessToken(IAuthServiceNewAccessTokenRequest refreshToken)
		{
			if (HelpFullFunctions.nullCheckObjectProps(refreshToken))
			{
				_logger.LogDebug("refreshToken parametresi null olamaz");
				throw new BadRequestException("refreshToken parametresi null olamaz");
			}

			if (!(await checkRefreshToken(refreshToken.RefreshToken)))
			{
				//token da hata var.Hata fırlatalım
				_logger.LogDebug("refresh token hatalı");
				throw new IdentityException("refresh token hatalı");
			}
			//token da hata yok.token oluşturalım
			DateTime accessTokenExpiration = DateTime.Now.AddMinutes(int.Parse(_configuration.GetSection("jwt:accessTokenExpirationInMinute").Value));
			string newAcessToken = CreateAccessToken(accessTokenExpiration);
			IAuthServiceNewAccessTokenResponse result = new IAuthServiceNewAccessTokenResponse() {
				AccessToken = newAcessToken, 
				AcessTokenExpiration = accessTokenExpiration
			};
			_logger.LogInformation("yeni token oluşturma başarılı");
			return result;
		}

		//newAccessToken functions end

	}
}
