using Data.Abstracts.Product;
using Entity.IProductRepository;
using Entity.IProductService;
using Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts.Product;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concretes.Product
{
	public class ProductService : IProductService
	{

		private readonly IProductRepository _productRepository;

		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}

		//null sistemini geliştirebiliriz
		//string verilerde isnullorempty fonksiyonu
		//int değerlerde nullable tip kullanımı


		//Create start
		private async Task<bool> CheckIsAlreadyProductInDb(string barcodeNumber, int marketId)
		{
			//parameter null check
			if ((barcodeNumber is null) || (marketId == 0))
			{
				throw new BadRequestException("barcode number veya market id  parametresi null olamaz");
			}
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse? checkIsAlreadyProductInDb = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			return checkIsAlreadyProductInDb is not null;
		}

		public async Task<IProductServiceCreateProductAsyncResponse> createProductAsync(IProductServiceCreateProductAsyncRequest product)
		{
			//parameter null check
			if (product is null)
			{
				throw new BadRequestException("product parametresi null olamaz");
			}

			//ürün hali hazırda veritabanında var mı onu kontrol edelim,eğer varsa confilict throw atalım,Yoksa ürünü veritabanına ekleyelim
			if (await CheckIsAlreadyProductInDb(product.BarcodeNumber, product.MarketId))
			{
				//veritabanında var o yüzden confilict dönelim
				throw new ConflictException($" barcode numarası {product.BarcodeNumber} ve market id {product.MarketId} olan ürün zaten var");
			}
			//veritabanında yok o yüzden ürünü kaydedelim
			IProductRepositoryCreateOneProductAsyncResponse result = await _productRepository.createOneProductAsync(_mapper.Map<IProductRepositoryCreateOneProductAsyncRequest>(product));
			//kaydedilen ürünü dönelim
			return _mapper.Map<IProductServiceCreateProductAsyncResponse>(result);
		}
		//Create End


		//Read Start

		public async Task<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse> getProductWithBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId)
		{
			//parameter null check
			if ((barcodeNumber is null) || (marketId == 0))
			{
				throw new BadRequestException("barcode number veya market id  parametresi null olamaz");
			}

			//öncelikle veritabanında parametrede verilen bilgilere göre bir ürün olup olmadığını kontrol edelim (check the product whether be or not in database)
			//eğer verilen bilgilere göre ürün yoksa data katmanı throw atar
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse result = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);

			//parametrede verilen bilgilere göre bir ürün var,ürünü dönelim
			return _mapper.Map<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>(result);
		}
		//Read End

		//Update Start
		public async Task<IProductServiceUpdateProductAsyncResponse> updateProductAsync(IProductServiceUpdateProductAsyncRequest product)
		{
			//parameter null check
			if (product is null)
			{
				throw new BadRequestException("product parametresi null olamaz");
			}

			IProductRepositoryUpdateOneProductAsyncResponse result = await _productRepository.updateOneProductAsync(_mapper.Map<IProductRepositoryUpdateOneProductAsyncRequest>(product));
			//update başarılı güncellenen ürünü dönelim
			return _mapper.Map<IProductServiceUpdateProductAsyncResponse>(result);
		}
		//Update End


		//Delete Start
		public async Task<bool> deleteProductAsync(string id)
		{
			// parameter null check
			if (id is null)
			{
				throw new BadRequestException("id parametresi null olamaz");
			}
			bool result = await _productRepository.deleteOneProductbyIdAsync(id);
			//silme başarılı ise true gelir,silme başarısız ise data katmanında throw atar.
			return result;
		}
		//Delete End

	}


}
