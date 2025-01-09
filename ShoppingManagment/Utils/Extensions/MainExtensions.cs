using Microsoft.AspNetCore.RateLimiting;
using ShoppingManagment.Utils.AutoMapper;

namespace ShoppingManagment.Utils.Extensions
{
	public static class MainExtensions
	{
		public static void setAutoMapperForMainLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForMainLayer));
		}

		public static void setRateLimiter(this IServiceCollection services,IConfiguration configuration)
		{
			services.AddRateLimiter(options =>
			{
				//bu istek sayılarını daha sonra güncelleyelim(mobile app kısmını yazdıktan sonra ihtiyaca göre belirleylim)
				int ratelimitMultiple = int.Parse(configuration.GetSection("RatelimitMultiple").Value);



				options.AddFixedWindowLimiter("marketController", options =>
				{
					options.AutoReplenishment = true;
					options.PermitLimit = ratelimitMultiple * 2;
					options.Window = TimeSpan.FromMinutes(1);
				});

				options.AddFixedWindowLimiter("orderController", options =>
				{
					options.AutoReplenishment = true;
					options.PermitLimit = ratelimitMultiple * 1;
					options.Window = TimeSpan.FromMinutes(1);
				});

				options.AddFixedWindowLimiter("productController", options =>
				{
					options.AutoReplenishment = true;
					options.PermitLimit = ratelimitMultiple * 3;
					options.Window = TimeSpan.FromMinutes(1);
				});
				

				
				//global limit
				//options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
				//	RateLimitPartition.GetFixedWindowLimiter(
				//		partitionKey: httpContext.User.Identity?.Name ?? httpContext.Request.Headers.Host.ToString(),
				//		factory: partition => new FixedWindowRateLimiterOptions
				//		{
				//			AutoReplenishment = true,
				//			PermitLimit = ratelimitMultiple * 1,
				//			Window = TimeSpan.FromMinutes(1)
				//		}));

				options.OnRejected = async (context, token) =>
				{
					context.HttpContext.Response.StatusCode = 429;
					await context.HttpContext.Response.WriteAsync("çok fazla istekte bulundunuz 1 dakika sonra tekrar deneyiniz", cancellationToken: token);
				};
			});
		}

	}
}
