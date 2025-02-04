using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts.Logger
{
	public interface IBaseLogger
	{
		void logTrace(string message);

		void logDebug(string message);
		void logInfo(string message);
		void logWarning(string message);
		void logError(string message);
		void logFatal(string message);
	}
}
