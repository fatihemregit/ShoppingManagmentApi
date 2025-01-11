using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
	public class IdentityException : CustomException
	{
		public IdentityException(string? message) : base(message,401)
		{
		}
	}
}
