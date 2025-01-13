using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.IAuthService;

namespace Business.Abstracts.Auth
{
	public interface IAuthService
	{
		Task<IAuthServiceCreateUserResponse> createUser(IAuthServiceCreateUserRequest user);

		Task<IAuthServiceNewAccessTokenResponse> newAccessToken(IAuthServiceNewAccessTokenRequest refreshToken);

		Task<IAuthServiceLoginResponse> login(IAuthServiceLoginRequest user);



	}
}
