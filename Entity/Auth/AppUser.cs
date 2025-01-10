using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Entity.Auth
{
    public class AppUser:IdentityUser<Guid>
    {
		public string RefreshToken { get; set; }
		public DateTime? RefreshTokenEndDate { get; set; }

	}
}
