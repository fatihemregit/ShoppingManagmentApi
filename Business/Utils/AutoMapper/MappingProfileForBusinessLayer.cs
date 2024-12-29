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
			CreateMap<IProductServiceGetProductWithBarcodeNumberAndMarketIdResponse, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse, IProductServiceGetProductWithBarcodeNumberAndMarketIdResponse>();
			// IProductServiceCreateProductRequest to IProductRepositoryCreateOneProductAsyncRequest
			CreateMap<IProductServiceCreateProductRequest, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, IProductServiceCreateProductRequest>();
			// IProductServiceCreateProductResponse to IProductRepositoryCreateOneProductAsyncResponse 
			CreateMap<IProductServiceCreateProductResponse, IProductRepositoryCreateOneProductAsyncResponse>();
			CreateMap<IProductRepositoryCreateOneProductAsyncResponse, IProductServiceCreateProductResponse>();
			//IProductServiceUpdateProductRequest to IProductRepositoryUpdateOneProductAsyncRequest
			CreateMap<IProductServiceUpdateProductRequest, IProductRepositoryUpdateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncRequest, IProductServiceUpdateProductRequest>();
			//IProductServiceUpdateProductResponse to IProductRepositoryUpdateOneProductAsyncResponse
			CreateMap<IProductServiceUpdateProductResponse, IProductRepositoryUpdateOneProductAsyncResponse>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncResponse, IProductServiceUpdateProductResponse>();


		}
	}
}
