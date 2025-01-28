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

		private readonly IMapper _mapper;

		public AuthController(IConfiguration configuration, IMapper mapper, IAuthService authService)
		{
			_configuration = configuration;
			_mapper = mapper;
			_authService = authService;
		}


		/*
		 fterm:Hs@3n9#@LV
		 Saturate6417:u%cH5AGCLVbXm4KPbkvt
		 Customary3029:anHsPVAH8#5uD@@X@!9J
		 */

		//yeni kullanıcı kaydı ve token işlemleri başlangıç
		
		//yeni kullanıcı kaydı oluşturma
		[HttpPost("register")]
		public async Task<IActionResult> CreateUser([FromBody] AuthControllerCreateUserRequest userRequest)
		{
			IAuthServiceCreateUserResponse authServiceResponse = await _authService.createUser(_mapper.Map<IAuthServiceCreateUserRequest>(userRequest));
			AuthControllerCreateUserResponse authControllerResponse = _mapper.Map<AuthControllerCreateUserResponse>(authServiceResponse);
			return Ok(authControllerResponse);

		}

		//yeni kullanıcı kaydı ve token işlemleri bitiş
		//hali hazırda olan kullanıcının RefreshToken ile AcessToken ını yenilemesi başlangıç

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
}
