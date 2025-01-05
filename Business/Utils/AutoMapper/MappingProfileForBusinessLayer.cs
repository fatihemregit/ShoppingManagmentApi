using AutoMapper;
using Business.Concretes.Market;
using Entity.IMarketRepository;
using Entity.IMarketService;
using Entity.IOrderRepository;
using Entity.IOrderService;
using Entity.IProductRepository;
using Entity.IProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utils.AutoMapper
{
	public class MappingProfileForBusinessLayer : Profile
	{
		public MappingProfileForBusinessLayer()
		{
			//IProductServiceGetProductWithBarcodeNumberAndMarketIdResponse to IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse
			CreateMap<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse, IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>();
			// IProductServiceCreateProductRequest to IProductRepositoryCreateOneProductAsyncRequest
			CreateMap<IProductServiceCreateProductAsyncRequest, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, IProductServiceCreateProductAsyncRequest>();
			// IProductServiceCreateProductResponse to IProductRepositoryCreateOneProductAsyncResponse 
			CreateMap<IProductServiceCreateProductAsyncResponse, IProductRepositoryCreateOneProductAsyncResponse>();
			CreateMap<IProductRepositoryCreateOneProductAsyncResponse, IProductServiceCreateProductAsyncResponse>();
			//IProductServiceUpdateProductRequest to IProductRepositoryUpdateOneProductAsyncRequest
			CreateMap<IProductServiceUpdateProductAsyncRequest, IProductRepositoryUpdateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncRequest, IProductServiceUpdateProductAsyncRequest>();
			//IProductServiceUpdateProductResponse to IProductRepositoryUpdateOneProductAsyncResponse
			CreateMap<IProductServiceUpdateProductAsyncResponse, IProductRepositoryUpdateOneProductAsyncResponse>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncResponse, IProductServiceUpdateProductAsyncResponse>();
			
			
			//IMarketServiceCreateMarketAsyncRequest to IMarketRepositoryCreateOneMarketAsyncRequest
			CreateMap<IMarketServiceCreateMarketAsyncRequest, IMarketRepositoryCreateOneMarketAsyncRequest>();
			CreateMap<IMarketRepositoryCreateOneMarketAsyncRequest, IMarketServiceCreateMarketAsyncRequest>();
			//IMarketServiceCreateMarketAsyncResponse to IMarketRepositoryCreateOneMarketAsyncResponse
			CreateMap<IMarketServiceCreateMarketAsyncResponse, IMarketRepositoryCreateOneMarketAsyncResponse>();
			CreateMap<IMarketRepositoryCreateOneMarketAsyncResponse, IMarketServiceCreateMarketAsyncResponse>();
			//IMarketServiceGetAllMarketsAsyncResponse to IMarketRepositoryGetAllAsyncResponse
			CreateMap<IMarketServiceGetAllMarketsAsyncResponse, IMarketRepositoryGetAllAsyncResponse>();
			CreateMap<IMarketRepositoryGetAllAsyncResponse, IMarketServiceGetAllMarketsAsyncResponse>();
			//IMarketServiceGetMarketByIdAsyncResponse to IMarketRepositoryGetOneMarketByIdAsyncResponse
			CreateMap<IMarketServiceGetMarketByIdAsyncResponse, IMarketRepositoryGetOneMarketByIdAsyncResponse>();
			CreateMap<IMarketRepositoryGetOneMarketByIdAsyncResponse, IMarketServiceGetMarketByIdAsyncResponse>();
			//IMarketServiceUpdateMarketAsyncRequest to IMarketRepositoryUpdateOneMarketAsyncRequest
			CreateMap<IMarketServiceUpdateMarketAsyncRequest, IMarketRepositoryUpdateOneMarketAsyncRequest>();
			CreateMap<IMarketRepositoryUpdateOneMarketAsyncRequest, IMarketServiceUpdateMarketAsyncRequest>();
			//IMarketServiceUpdateMarketAsyncResponse to IMarketRepositoryUpdateOneMarketAsyncResponse
			CreateMap<IMarketServiceUpdateMarketAsyncResponse, IMarketRepositoryUpdateOneMarketAsyncResponse>();
			CreateMap<IMarketRepositoryUpdateOneMarketAsyncResponse, IMarketServiceUpdateMarketAsyncResponse>();


			//IOrderServiceGetAllOrdersAsyncResponse to IOrderRepositoryGetAllOrdersAsyncResponse
			CreateMap<IOrderServiceGetAllOrdersAsyncResponse, IOrderRepositoryGetAllOrdersAsyncResponse>();
			CreateMap<IOrderRepositoryGetAllOrdersAsyncResponse, IOrderServiceGetAllOrdersAsyncResponse>();

			//IOrderServiceGetOrdersByOrderIdAsyncResponse to IOrderRepositoryGetOrdersByOrderIdAsyncResponse>
			CreateMap<IOrderServiceGetOrdersByOrderIdAsyncResponse, IOrderRepositoryGetOrdersByOrderIdAsyncResponse>();
			CreateMap<IOrderRepositoryGetOrdersByOrderIdAsyncResponse, IOrderServiceGetOrdersByOrderIdAsyncResponse>();

			//IOrderServiceGetOrderByRowIdAsyncResponse to IOrderRepositoryGetOneOrderByRowIdAsyncResponse
			CreateMap<IOrderServiceGetOrderByRowIdAsyncResponse, IOrderRepositoryGetOneOrderByRowIdAsyncResponse>();
			CreateMap<IOrderRepositoryGetOneOrderByRowIdAsyncResponse, IOrderServiceGetOrderByRowIdAsyncResponse>();

		}
	}
}
