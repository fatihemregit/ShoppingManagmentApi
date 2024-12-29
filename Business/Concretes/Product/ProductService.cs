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

namespace Business.Concretes.Product
{
	public class ProductService: IProductService
	{

		private readonly IProductRepository _productRepository;

		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}


		//Create start
		private async Task<bool> CheckIsAlreadyProductInDb(string barcodeNumber, int marketId)
		{
			//will add parameter null check
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse? checkIsAlreadyProductInDb = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			return checkIsAlreadyProductInDb is not null;
		}
		
		public async Task<Exception> createProductAsync(IProductServiceCreateProductRequest product)
		{
			//will add parameter null check
			//ürün hali hazırda veritabanında var mı onu kontrol edelim,eğer varsa confilict dönelim,Yoksa ürünü veritabanına ekleyelim
			if (await CheckIsAlreadyProductInDb(product.BarcodeNumber, product.MarketId))
			{
				//veritabanında var o yüzden confilict dönelim
				return new ConflictException("barcode numarası  ve market id olan ürün zaten var");
			}
			//veritabanında yok o yüzden ürünü kaydedelim
			IProductRepositoryCreateOneProductAsyncResponse? result = await _productRepository.createOneProductAsync(_mapper.Map<IProductRepositoryCreateOneProductAsyncRequest>(product));
			if (result is null)
			{
				//kayıt başarısız BadRequestException Dönelim
				return new BadRequestException("kayıt başarısız oldu");
			}
			//kayıt başarılı OkException Dönelim
			return new OkException<IProductServiceCreateProductAsyncResponse>("kayıt başarılı", _mapper.Map<IProductServiceCreateProductAsyncResponse>(result));
		}
		//Create End


		//Read Start

		public async Task<Exception> getProductWithBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId)
		{
			//will add parameter null check
			//öncelikle veritabanında parametrede verilen bilgilere göre bir ürün olup olmadığını kontrol edelim (check the product whether be or not in database)
			//eğer parametrede verilen bilgilere göre bir ürün yoksa result  değişkeni null gelir
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse? result = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			if (result is null)
			{
				//parametrede verilen bilgilere göre bir ürün yok NotFound dönelim
				return new NotFoundException("ürün bulunamadı");
			}
			//parametrede verilen bilgilere göre bir ürün var OkException dönelim
			return new OkException<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>("ürün bulundu", _mapper.Map<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>(result));
		}
		//Read End
		
		//Update Start
		public async Task<Exception> updateProductAsync(IProductServiceUpdateProductAsyncRequest product)
		{
			//will add parameter null check
			IProductRepositoryUpdateOneProductAsyncResponse? result = await _productRepository.updateOneProductAsync(_mapper.Map<IProductRepositoryUpdateOneProductAsyncRequest>(product));
			if (result is null)
			{
				//update başarısız BadRequestException Dönelim
				return new BadRequestException("güncelleme başarısız oldu");
			}
			//update başarılı OkException Dönelim
			return new OkException<IProductServiceUpdateProductAsyncResponse>("güncelleme başarılı",_mapper.Map<IProductServiceUpdateProductAsyncResponse>(result));
		}
		//Update End


		//Delete Start
		public async Task<Exception> deleteProductAsync(string id)
		{
			//will add parameter null check
			bool result = await _productRepository.deleteOneProductbyIdAsync(id);
			if (result)
			{
				//silme başarılı OkException Dönelim
				return new OkException<IProductServiceDeleteProductAsyncResponse>("silme başarılı",new IProductServiceDeleteProductAsyncResponse(result));

			}
			//silme başarısız BadRequestException Dönelim
			return new BadRequestException("silme başarısız");
		}
		//Delete End

	}


}
