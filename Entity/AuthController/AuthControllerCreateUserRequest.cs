using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.AuthController
{
	public class AuthControllerCreateUserRequest
	{
		public string UserName { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }
	}
}
