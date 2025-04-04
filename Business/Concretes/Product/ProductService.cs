﻿using Data.Abstracts.Product;
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
using Business.Utils.Functions;

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

		//Create start
		private async Task<bool> CheckIsAlreadyProductInDb(string barcodeNumber, int marketId)
		{
			//parameter null check
			if (HelpFullFunctions.nullCheckObjectProps(new {barcodeNumber = barcodeNumber,marketId = marketId}))
			{
				throw new BadRequestException("barcode number veya market id  parametresi null olamaz");
			}
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse? checkIsAlreadyProductInDb = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			return checkIsAlreadyProductInDb is not null;
		}

		public async Task<IProductServiceCreateProductAsyncResponse> createProductAsync(IProductServiceCreateProductAsyncRequest product)
		{
			//parameter null check
			//obje değerleri tek tek kontrol edilebilir(bunun için bir fonksiyon yazabiliriz)
			if (HelpFullFunctions.nullCheckObjectProps(product))
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
			IProductRepositoryCreateOneProductAsyncResponse? result = await _productRepository.createOneProductAsync(_mapper.Map<IProductRepositoryCreateOneProductAsyncRequest>(product));
			if (result is null)
			{
				throw new BadRequestException("Yeni Ürün Ekleme İşlemi Başarısız");
			}
			//kaydedilen ürünü dönelim
			return _mapper.Map<IProductServiceCreateProductAsyncResponse>(result);
		}
		//Create End


		//Read Start

		public async Task<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse> getProductWithBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId)
		{
			//parameter null check
			if (HelpFullFunctions.nullCheckObjectProps(new { barcodeNumber = barcodeNumber, marketId = marketId }))
			{
				throw new BadRequestException("barcode number veya market id  parametresi null olamaz");
			}

			//öncelikle veritabanında parametrede verilen bilgilere göre bir ürün olup olmadığını kontrol edelim (check the product whether be or not in database)
			//eğer verilen bilgilere göre ürün yoksa null gelir
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse? result = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			if (result is null)
			{
				throw new NotFoundException($"barcode number i {barcodeNumber} olan,market id si {marketId} olan ürün bulunamadı");
			}
			//parametrede verilen bilgilere göre bir ürün var,ürünü dönelim
			return _mapper.Map<IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse>(result);
		}
		//Read End

		//Update Start
		public async Task<IProductServiceUpdateProductAsyncResponse> updateProductAsync(IProductServiceUpdateProductAsyncRequest product)
		{
			//parameter null check
			if (HelpFullFunctions.nullCheckObjectProps(product))
			{
				throw new BadRequestException("product parametresi null olamaz");
			}

			IProductRepositoryUpdateOneProductAsyncResponse? result = await _productRepository.updateOneProductAsync(_mapper.Map<IProductRepositoryUpdateOneProductAsyncRequest>(product));
			//update başarısız badrequest dönelim
			if (result is null)
			{
				throw new BadRequestException("ürün güncelleme başarısız");
			}

			//update başarılı güncellenen ürünü dönelim
			return _mapper.Map<IProductServiceUpdateProductAsyncResponse>(result);
		}
		//Update End


		//Delete Start
		public async Task<bool> deleteProductAsync(string id)
		{
			// parameter null check
			if (HelpFullFunctions.nullCheckObjectProps(new { id = id}))
			{
				throw new BadRequestException("id parametresi null olamaz");
			}
			//silme başarılı ise true gelir,silme başarısız ise false gelir
			bool result = await _productRepository.deleteOneProductbyIdAsync(id);
			if (!result)
			{
				throw new BadRequestException("silme işlemi başarısız");
			}

			return result;
		}
		//Delete End

	}


}
