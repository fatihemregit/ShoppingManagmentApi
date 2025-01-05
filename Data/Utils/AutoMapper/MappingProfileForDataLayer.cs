using AutoMapper;
using Entity.Dto;
using Entity.IProductRepository;
using Entity.IMarketRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.IOrderRepository;

namespace Data.Utils.AutoMapper
{
	public class MappingProfileForDataLayer : Profile
	{
		public MappingProfileForDataLayer()
		{

			//ProductDto to IProductRepositoryCreateOneProductAsyncRequest
			CreateMap<ProductDto, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, ProductDto>();
			// ProductDto to IProductRepositoryCreateOneProductAsyncResponse 
			CreateMap<IProductRepositoryCreateOneProductAsyncResponse, ProductDto>();
			CreateMap<ProductDto, IProductRepositoryCreateOneProductAsyncResponse>();

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

			// MarketDto to IMarketRepositoryGetOneMarketByNameAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryGetOneMarketByNameAsyncResponse>();
			CreateMap<IMarketRepositoryGetOneMarketByNameAsyncResponse, MarketDto>();

			//MarketDto to IMarketRepositoryUpdateOneMarketAsyncResponse
			CreateMap<MarketDto, IMarketRepositoryUpdateOneMarketAsyncResponse>();
			CreateMap<IMarketRepositoryUpdateOneMarketAsyncResponse, MarketDto>();




			//OrderDto to IOrderRepositoryCreateOneOrderAsyncRequest
			CreateMap<OrderDto, IOrderRepositoryCreateOneOrderAsyncRequest>();
			CreateMap<IOrderRepositoryCreateOneOrderAsyncRequest, OrderDto>();
			//OrderDto to IOrderRepositoryCreateOneOrderAsyncResponse
			CreateMap<OrderDto, IOrderRepositoryCreateOneOrderAsyncResponse>();
			CreateMap<IOrderRepositoryCreateOneOrderAsyncResponse, OrderDto>();

			//OrderDto to IOrderRepositoryGetAllOrdersAsyncResponse
			CreateMap<OrderDto, IOrderRepositoryGetAllOrdersAsyncResponse>();
			CreateMap<IOrderRepositoryGetAllOrdersAsyncResponse, OrderDto>();
			//OrderDto to IOrderRepositoryGetOrdersByOrderIdAsyncResponse
			CreateMap<OrderDto, IOrderRepositoryGetOrdersByOrderIdAsyncResponse>();
			CreateMap<IOrderRepositoryGetOrdersByOrderIdAsyncResponse, OrderDto>();

			//OrderDto to IOrderRepositoryGetOneOrderByRowIdAsyncResponse
			CreateMap<OrderDto, IOrderRepositoryGetOneOrderByRowIdAsyncResponse>();
			CreateMap<IOrderRepositoryGetOneOrderByRowIdAsyncResponse, OrderDto>();

			//OrderDto to IOrderRepositoryUpdateOneOrderAsyncResponse
			CreateMap<OrderDto, IOrderRepositoryUpdateOneOrderAsyncResponse>();
			CreateMap<IOrderRepositoryUpdateOneOrderAsyncResponse, OrderDto>();

		}
	}
}
