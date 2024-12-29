﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
	public class NotFoundException : CustomException
	{
		public NotFoundException(string? message) : base(message,404)
		{
		}
	}
}
