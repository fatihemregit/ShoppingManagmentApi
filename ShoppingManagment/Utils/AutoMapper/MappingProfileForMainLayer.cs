using AutoMapper;
using Entity.IMarketService;
using Entity.MarketController;

using Entity.IProductService;
using Entity.ProductController;
using ShoppingManagment.Controllers;

namespace ShoppingManagment.Utils.AutoMapper
{
	public class MappingProfileForMainLayer : Profile
	{
		public MappingProfileForMainLayer()
		{
			//IProductServiceCreateProductAsyncRequest to ProductControllerCreateProductAsyncRequest
			CreateMap<IProductServiceCreateProductAsyncRequest, ProductControllerCreateProductAsyncRequest>();
			CreateMap<ProductControllerCreateProductAsyncRequest, IProductServiceCreateProductAsyncRequest>();
			//IProductServiceCreateProductAsyncResponse to ProductControllerCreateProductAsyncResponse
			CreateMap<IProductServiceCreateProductAsyncResponse, ProductControllerCreateProductAsyncResponse>();
			CreateMap<ProductControllerCreateProductAsyncResponse, IProductServiceCreateProductAsyncResponse>();
			//IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse to ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse
			CreateMap<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse, ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse>();
			CreateMap<ProductControllerGetProductWithBarcodeNumberAndMarketIdAsyncResponse, IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>();
			//IProductServiceUpdateProductAsyncRequest to ProductControllerUpdateProductAsyncRequest
			CreateMap<IProductServiceUpdateProductAsyncRequest, ProductControllerUpdateProductAsyncRequest>();
			CreateMap<ProductControllerUpdateProductAsyncRequest, IProductServiceUpdateProductAsyncRequest>();
			//IProductServiceUpdateProductAsyncResponse to ProductControllerUpdateProductAsyncResponse
			CreateMap<IProductServiceUpdateProductAsyncResponse, ProductControllerUpdateProductAsyncResponse>();
			CreateMap<ProductControllerUpdateProductAsyncResponse, IProductServiceUpdateProductAsyncResponse>();
			
			
			//IMarketServiceCreateMarketAsyncRequest to MarketControllerCreateMarketAsyncRequest
			CreateMap<IMarketServiceCreateMarketAsyncRequest, MarketControllerCreateMarketAsyncRequest>();
			CreateMap<MarketControllerCreateMarketAsyncRequest, IMarketServiceCreateMarketAsyncRequest>();
			//IMarketServiceCreateMarketAsyncResponse to MarketControllerCreateMarketAsyncResponse
			CreateMap<IMarketServiceCreateMarketAsyncResponse, MarketControllerCreateMarketAsyncResponse>();
			CreateMap<MarketControllerCreateMarketAsyncResponse, IMarketServiceCreateMarketAsyncResponse>();
			//IMarketServiceGetAllMarketsAsyncResponse to MarketControllerGetAllMarketsAsyncResponse
			CreateMap<IMarketServiceGetAllMarketsAsyncResponse, MarketControllerGetAllMarketsAsyncResponse>();
			CreateMap<MarketControllerGetAllMarketsAsyncResponse, IMarketServiceGetAllMarketsAsyncResponse>();
			//IMarketServiceGetMarketByIdAsyncResponse to MarketControllerGetMarketByIdAsyncResponse
			CreateMap<IMarketServiceGetMarketByIdAsyncResponse, MarketControllerGetMarketByIdAsyncResponse>();
			CreateMap<MarketControllerGetMarketByIdAsyncResponse, IMarketServiceGetMarketByIdAsyncResponse>();
			//IMarketServiceUpdateMarketAsyncRequest to MarketControllerUpdateMarketAsyncRequest
			CreateMap<IMarketServiceUpdateMarketAsyncRequest, MarketControllerUpdateMarketAsyncRequest>();
			CreateMap<MarketControllerUpdateMarketAsyncRequest, IMarketServiceUpdateMarketAsyncRequest>();
			//IMarketServiceUpdateMarketAsyncResponse to MarketControllerUpdateMarketAsyncResponse
			CreateMap<IMarketServiceUpdateMarketAsyncResponse, MarketControllerUpdateMarketAsyncResponse>();
			CreateMap<MarketControllerUpdateMarketAsyncResponse, IMarketServiceUpdateMarketAsyncResponse>();

		}
	}
}
