using Data.EfCore.Context;
using Entity.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using ShoppingManagment.Utils.AutoMapper;
using System.Text;

namespace ShoppingManagment.Utils.Extensions
{
	public static class MainExtensions
	{
		public static void setAutoMapperForMainLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForMainLayer));
		}

		public static void setRateLimiter(this IServiceCollection services, IConfiguration configuration)
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

		public static void setAuthentication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentity<AppUser, AppRole>(options =>
			{
				options.Password.RequiredLength = 8;//şifrenin kaç haneli olduğu
				options.Password.RequireNonAlphanumeric = true; //Alfanumerik zorunluluğunu kaldırıyoruz.
				options.Password.RequireLowercase = true; //Küçük harf zorunluluğunu kaldırıyoruz.
				options.Password.RequireUppercase = true; //Büyük harf zorunluluğunu kaldırıyoruz.
				options.Password.RequireDigit = true; //0-9 arası sayısal karakter zorunluluğunu kaldırıyoruz.
				options.User.RequireUniqueEmail = true; //Email adreslerini tekilleştiriyoruz.
				options.User.AllowedUserNameCharacters = "abcçdefghiıjklmnoöpqrsştuüvwxyzABCÇDEFGHIİJKLMNOÖPQRSŞTUÜVWXYZ0123456789-._@+"; //Kullanıcı adında geçerli olan karakterleri belirtiyoruz.

			}).AddEntityFrameworkStores<ApplicationDbContext>();


			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateAudience = true,
					ValidateIssuer = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = configuration.GetSection("jwt:issuer").Value,
					ValidAudience = configuration.GetSection("jwt:audience").Value,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("jwt:securityKey").Value)),
					ClockSkew = TimeSpan.Zero
				};
			}
			);

		}




	}
}
