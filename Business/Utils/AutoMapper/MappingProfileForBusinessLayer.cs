using AutoMapper;
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


		}
	}
}
