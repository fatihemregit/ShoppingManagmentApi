﻿namespace Entity.IAuthService
{
	public class IAuthServiceCreateUserRequest
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}