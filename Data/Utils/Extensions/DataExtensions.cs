﻿using Data.Abstracts.Logger;
using Data.Abstracts.Market;
using Data.Abstracts.Order;
using Data.Abstracts.Product;
using Data.EfCore;
using Data.EfCore.Context;
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
		public static void ConfigureSqlContextForDataLayer(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<ApplicationDbContext>((options) =>
			{

				options.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
					x => x.MigrationsAssembly("Data")
					);

			});
		}
		public static void setAutoMapperForDataLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForDataLayer));
		}

		public static void setInterfaceConcretesForDataLayer(this IServiceCollection services)
		{
			services.AddScoped<IProductRepository,ProductRepository>();
			services.AddScoped<IMarketRepository,MarketRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			services.AddScoped<IBaseLogger, NLogger>();
		}



	}
}
