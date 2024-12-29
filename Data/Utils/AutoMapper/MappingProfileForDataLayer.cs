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

			//ProductDto to IProductRepositoryCreateOneProductAsyncRequest
			CreateMap<ProductDto, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, ProductDto>();
			// IProductRepositoryCreateOneProductAsyncResponse to IProductRepositoryCreateOneProductAsyncRequest
			CreateMap<IProductRepositoryCreateOneProductAsyncResponse, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, IProductRepositoryCreateOneProductAsyncResponse>();

			//ProductDto to IProductRepositoryGetAllAsyncResponse
			CreateMap<ProductDto, IProductRepositoryGetAllAsyncResponse>();
			CreateMap<IProductRepositoryGetAllAsyncResponse, ProductDto>();

			//ProductDto to IProductRepositoryGetOneProductByIdAsyncResponse
			CreateMap<ProductDto, IProductRepositoryGetOneProductByIdAsyncResponse>();
			CreateMap<IProductRepositoryGetOneProductByIdAsyncResponse, ProductDto>();

			//ProductDto to IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse
			CreateMap<ProductDto, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse, ProductDto>();
			//ProductDto to IProductRepositoryUpdateOneProductAsyncResponse
			CreateMap<ProductDto, IProductRepositoryUpdateOneProductAsyncResponse>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncResponse, ProductDto>();


			//MarketDto to IMarketRepositoryCreateOneMarketAsyncRequest
			CreateMap<MarketDto, IMarketRepositoryCreateOneMarketAsyncRequest>();
			CreateMap<IMarketRepositoryCreateOneMarketAsyncRequest, MarketDto>();
			//MarketDto to IMarketRepositoryCreateOneMarketAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryCreateOneMarketAsyncResponse>();
			CreateMap<IMarketRepositoryCreateOneMarketAsyncResponse, MarketDto>();

			//MarketDto to IMarketRepositoryGetAllAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryGetAllAsyncResponse>();
			CreateMap<IMarketRepositoryGetAllAsyncResponse, MarketDto>();
			//MarketDto to IMarketRepositoryGetOneMarketByIdAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryGetOneMarketByIdAsyncResponse>();
			CreateMap<IMarketRepositoryGetOneMarketByIdAsyncResponse, MarketDto>();
			//MarketDto to IMarketRepositoryUpdateOneMarketAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryUpdateOneMarketAsyncResponse>();
			CreateMap<IMarketRepositoryUpdateOneMarketAsyncResponse, MarketDto>();


		}
	}
}
