//using Data.Abstracts.Logger;
using Data.Abstracts.Market;
using Data.Abstracts.Order;
using Data.Abstracts.Product;
using Data.EfCore;
using Data.EfCore.Context;
using Data.PostgreSql.Context;
using Data.Utils.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils.Extensions
{
	public static class DataExtensions
	{
		

		public static void ConfigureSqlContextForDataLayerSqlServer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContextSqlServer>((options) =>
			{

				//options.UseSqlServer(configuration.GetConnectionString("sqlConnectionSqlServer"),
				//	x => x.MigrationsAssembly("Data")
				//	);
				options.UseSqlServer(configuration.GetConnectionString("sqlConnectionSqlServerRemote"),
					x => x.MigrationsAssembly("Data")
					);

			});
		}

		public static void ConfigureSqlContextForDataLayerPostgre(this IServiceCollection services, IConfiguration configuration)
		{
			//services.AddDbContext<ApplicationDbContextPostgre>((options) =>
			//{

			//	//options.UseNpgsql(configuration.GetConnectionString("sqlConnectionPostgreDb"),
			//	//	x => x.MigrationsAssembly("Data")
			//	//	);
			//	options.UseNpgsql(configuration.GetConnectionString("sqlConnectionPostgreDbRemote"),
			//		x => x.MigrationsAssembly("Data")
			//		);
			//});
		}

		public static void setAutoMapperForDataLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForDataLayer));
		}

		public static void setInterfaceConcretesForDataLayer(this IServiceCollection services)
		{
			//Sql
			//services.AddScoped<IProductRepository,ProductRepository>();
			//services.AddScoped<IMarketRepository,MarketRepository>();
			//services.AddScoped<IOrderRepository, OrderRepository>();
			//services.AddScoped<IBaseLogger, NLogger>();
			//Postgre
			services.AddScoped<IProductRepository,ProductRepository>();
			services.AddScoped<IMarketRepository, MarketRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}



	}
}
