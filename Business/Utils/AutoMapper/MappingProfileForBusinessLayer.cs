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
			//IProductServiceGetProductWithBarcodeNumberAndMarketId to IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync
			CreateMap<IProductServiceGetProductWithBarcodeNumberAndMarketId, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse, IProductServiceGetProductWithBarcodeNumberAndMarketId>();
			// IProductServiceCreateProduct to IProductRepositoryCreateOneProductAsync
			CreateMap<IProductServiceCreateProduct, IProductRepositoryCreateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryCreateOneProductAsyncRequest, IProductServiceCreateProduct>();
			//IProductServiceUpdateProduct to IProductRepositoryUpdateOneProductAsync
			CreateMap<IProductServiceUpdateProduct, IProductRepositoryUpdateOneProductAsyncRequest>();
			CreateMap<IProductRepositoryUpdateOneProductAsyncRequest, IProductServiceUpdateProduct>();


		}
	}
}
