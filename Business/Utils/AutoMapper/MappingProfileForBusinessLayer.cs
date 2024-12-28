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
			CreateMap<IProductServiceGetProductWithBarcodeNumberAndMarketId, IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync>();
			CreateMap<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync, IProductServiceGetProductWithBarcodeNumberAndMarketId>();
			// IProductServiceCreateProduct to IProductRepositoryCreateOneProductAsync
			CreateMap<IProductServiceCreateProduct, IProductRepositoryCreateOneProductAsync>();
			CreateMap<IProductRepositoryCreateOneProductAsync, IProductServiceCreateProduct>();
			//IProductServiceUpdateProduct to IProductRepositoryUpdateOneProductAsync
			CreateMap<IProductServiceUpdateProduct, IProductRepositoryUpdateOneProductAsync>();
			CreateMap<IProductRepositoryUpdateOneProductAsync, IProductServiceUpdateProduct>();


		}
	}
}
