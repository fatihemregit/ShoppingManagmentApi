using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Exceptions
{
	public class CustomException : Exception
	{
        public int DevelopmentEnvironmentStatusCode { get; set; }

        public int ProductionEnvironmentStatusCode { get; set; }
		public CustomException(string? message, int developmentEnvironmentStatusCode, int productionEnvironmentStatusCode = 500) : base(message)
		{
			DevelopmentEnvironmentStatusCode = developmentEnvironmentStatusCode;
			ProductionEnvironmentStatusCode = productionEnvironmentStatusCode;
		}
	}
}
