using Business.Abstracts.Auth;
//using Business.Abstracts.Logger;
using Business.Abstracts.Market;
using Business.Abstracts.Order;
using Business.Abstracts.Product;
using Business.Concretes.Auth;
//using Business.Concretes.Logger;
using Business.Concretes.Market;
using Business.Concretes.Order;
using Business.Concretes.Product;
using Business.Utils.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.Extensions
{
	public static class ServiceExtensions
	{
		public static void setAutoMapperForBusinessLayer(this IServiceCollection services)
		{
			services.AddAutoMapper(typeof(MappingProfileForBusinessLayer));
		}

		public static void setInterfaceConcretesForBusinessLayer(this IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			services.AddScoped<IMarketService,MarketService>();
			services.AddScoped<IOrderService, OrderService>();
			services.AddScoped<IAuthService, AuthService>();
			//services.AddScoped<ILoggerService, LoggerService>();
		}

	}
}
