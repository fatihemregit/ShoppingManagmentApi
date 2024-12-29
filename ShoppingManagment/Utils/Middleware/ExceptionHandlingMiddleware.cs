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

			context.Response.ContentType = "application/json";
			int statuscodeForCustomException = (exception is CustomException) ? ((CustomException)exception).StatusCode : 500;
			context.Response.StatusCode = _env.IsDevelopment() ? statuscodeForCustomException: (int)HttpStatusCode.InternalServerError;

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
