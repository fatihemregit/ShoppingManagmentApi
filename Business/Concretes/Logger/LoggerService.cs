using Business.Abstracts.Logger;
using Data.Abstracts.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Logger
{
	public class LoggerService : ILoggerService
	{

		private readonly IBaseLogger _logger;

		public LoggerService(IBaseLogger logger)
		{
			_logger = logger;
		}

		public void logToError(int statusCode, string message, string stackTrace)
		{
			_logger.logError($"Created Error In Global Error Handling|Error Status Code:{statusCode}|message:{message}|stackTrace:{stackTrace}");
		}


		private string writeObject(object item)
		{
			//objenin proplarından biri null geldiğinde ne yapacağız?
			//objenin proplarından biri referans(nesne) geldiğinde ne yapacağız?
			string result = "";
			Type type = item.GetType();
			result += $"object Type : {type.Name}|";
			PropertyInfo[] properties = type.GetProperties();

			foreach (var prop in properties)
			{
				object value = prop.GetValue(item);
				result += $"{prop.Name}: {value}|";
			}
			return result;
		}
		public void sucessInBusinessLayer(string message, object item)
		{
			_logger.logInfo($"Sucessful in Business Layer|message:{message}|object Info:({writeObject(item)})");
		}
		public void unSucessInBusinessLayer(string message, object item)
		{
			_logger.logWarning($"Unsucessful in Business Layer|message:{message}|object Info:{writeObject(item)}");
		}
		public void sucessInDataLayer(string message, object item)
		{
			_logger.logInfo($"Sucessful in Data Layer|message:{message}|object Info:({writeObject(item)})");
		}
		public void unSucessInDataLayer(string message, object item)
		{
			//Öneri.Veritabanı hatalarınıdamı eklesek?
			_logger.logWarning($"Unsucessful in Data Layer|message:{message}|object Info:{writeObject(item)}");
		}
	}
}
