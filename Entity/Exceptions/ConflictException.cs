using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
	public class ConflictException : CustomException
	{
		public ConflictException(string? message) : base(message, 409,409)
		{
		}
	}
}
