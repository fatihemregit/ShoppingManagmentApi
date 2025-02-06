using Entity.Exceptions;
using System.Diagnostics;
using System.Net;

namespace ShoppingManagment.Utils.Middleware
{
	public class ExceptionHandlingMiddleware
	{
		private readonly RequestDelegate _next;
		private readonly IWebHostEnvironment _env;

		public ExceptionHandlingMiddleware(RequestDelegate next, IWebHostEnvironment env)
		{
			_next = next;
			_env = env;
		}
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
            Console.WriteLine("handle exception çalıştı");
			context.Response.ContentType = "application/json";
			if (exception is CustomException)
			{
				context.Response.StatusCode = _env.IsDevelopment() ? ((CustomException)exception).DevelopmentEnvironmentStatusCode : ((CustomException)exception).ProductionEnvironmentStatusCode;
			}
			else
			{
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			}
			//Öneri : customException sa loglamayı zaten yapmış oluruz. o yüzden sadece dahili hataları log error yapalım

			var response = new
			{
				status = context.Response.StatusCode,
				message = _env.IsDevelopment() ? exception.Message : "An unexpected error occurred.",
				stackTrace = _env.IsDevelopment() ? exception.StackTrace : ""
			};

			if (_env.IsDevelopment())
			{
                Console.WriteLine(exception.StackTrace);
			}

			return context.Response.WriteAsJsonAsync(response);
		}


	}
}
