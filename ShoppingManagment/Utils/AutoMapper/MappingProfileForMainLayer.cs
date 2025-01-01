using AutoMapper;
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

		}
	}
}
