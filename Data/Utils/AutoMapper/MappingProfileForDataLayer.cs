using AutoMapper;
using Entity.Dto;
using Entity.IProductRepository;
using Entity.IMarketRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Utils.AutoMapper
{
	public class MappingProfileForDataLayer : Profile
	{
		public MappingProfileForDataLayer()
		{

			//ProductDto to IProductRepositoryCreateOneProduct
			CreateMap<ProductDto, IProductRepositoryCreateOneProductAsync>();
			CreateMap<IProductRepositoryCreateOneProductAsync, ProductDto>();

			//ProductDto to IProductRepositoryGetAll
			CreateMap<ProductDto, IProductRepositoryGetAllAsync>();
			CreateMap<IProductRepositoryGetAllAsync, ProductDto>();

			//ProductDto to IProductRepositoryGetOneProductById
			CreateMap<ProductDto, IProductRepositoryGetOneProductByIdAsync>();
			CreateMap<IProductRepositoryGetOneProductByIdAsync, ProductDto>();

			//ProductDto to IProductRepositoryGetOneProductByBarcodeNumberAndMarketId
			CreateMap<ProductDto, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync, ProductDto>();

			//MarketDto to IMarketRepositoryCreateOneMarketAsync
			CreateMap<MarketDto, IMarketRepositoryCreateOneMarketAsync>();
			CreateMap<IMarketRepositoryCreateOneMarketAsync, MarketDto>();
			//MarketDto to IMarketRepositoryGetAllAsync
			CreateMap<MarketDto, IMarketRepositoryGetAllAsync>();
			CreateMap<IMarketRepositoryGetAllAsync, MarketDto>();
			//MarketDto to IMarketRepositoryGetOneMarketByIdAsync
			CreateMap<MarketDto, IMarketRepositoryGetOneMarketByIdAsync>();
			CreateMap<IMarketRepositoryGetOneMarketByIdAsync, MarketDto>();

		}
	}
}
