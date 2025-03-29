using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Abstracts.Logging
{
	public interface ILoggingRepository
	{
		void logTrace(string message);

		void logDebug(string message);
		void logInfo(string message);
		void logWarning(string message);
		void logError(string message);
		void logFatal(string message);
	}
}
