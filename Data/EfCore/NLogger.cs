using Data.Abstracts.Logger;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class NLogger : IBaseLogger
	{
		private readonly ILogger _logger;


		public NLogger(ILogger logger)
		{
			_logger = logger;
		}

		public void logTrace(string message)
		{
			_logger.LogTrace(message);
		}
		public void logDebug(string message)
		{
			_logger.LogDebug(message);
		}

		public void logInfo(string message)
		{
			_logger.LogInformation(message);
		}

		public void logWarning(string message)
		{
			_logger.LogWarning(message);
		}

		public void logError(string message)
		{
			_logger.LogError(message);
		}

		public void logFatal(string message)
		{
			_logger.LogCritical(message);
		}

		

		

		
	}
}
