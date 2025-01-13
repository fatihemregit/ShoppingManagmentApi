using Business.Abstracts.Auth;
using Entity.Auth;
using Entity.IAuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Auth
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<AppUser> _userManager;

		private readonly IConfiguration _configuration;

		public AuthService(UserManager<AppUser> userManager, IConfiguration configuration)
		{
			_userManager = userManager;
			_configuration = configuration;
		}


		public Task<IAuthServiceCreateUserResponse> createUser(IAuthServiceCreateUserRequest user)
		{
			throw new NotImplementedException();
		}

		public Task<IAuthServiceLoginResponse> login(IAuthServiceLoginRequest user)
		{
			throw new NotImplementedException();
		}

		public Task<IAuthServiceNewAccessTokenResponse> newAccessToken(IAuthServiceNewAccessTokenRequest refreshToken)
		{
			throw new NotImplementedException();
		}
	}
}
