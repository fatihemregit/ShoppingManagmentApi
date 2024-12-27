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

namespace Business.Concretes.Product
{
	public class ProductService
	{

		private readonly IProductRepository _productRepository;

		private readonly IMapper _mapper;

		public ProductService(IProductRepository productRepository, IMapper mapper)
		{
			_productRepository = productRepository;
			_mapper = mapper;
		}



		public async Task<Exception> getProductWithBarcodeNumberAndMarketId(string barcodeNumber, int marketId)
		{
			//öncelikle veritabanında parametrede verilen bilgilere göre bir ürün olup olmadığını kontrol edelim (check the product whether be or not in database)
			//eğer parametrede verilen bilgilere göre bir ürün yoksa result  değişkeni null gelir
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync? result = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			if (result is null)
			{
				//parametrede verilen bilgilere göre bir ürün yok NotFound dönelim
				return new NotFoundException("ürün bulunamadı");
			}
			//parametrede verilen bilgilere göre bir ürün var Succeeded dönelim
			return new OkException<IProductServiceGetProductWithBarcodeNumberAndMarketId>("ürün bulundu", _mapper.Map<IProductServiceGetProductWithBarcodeNumberAndMarketId>(result));
		}

		public async Task<Exception> createProduct(IProductServiceCreateProduct product)
		{
			//ürün hali hazırda veritabanında var mı onu kontrol edelim,eğer varsa confilict dönelim,Yoksa ürünü veritabanına ekleyelim
			if (await CheckIsAlreadyProductInDb(product.BarcodeNumber, product.MarketId))
			{
				//veritabanında var o yüzden confilict dönelim
				return new ConflictException("barcode numarası  ve market id olan ürün zaten var");
			}
			//veritabanında yok o yüzden ürünü kaydedelim
			IProductRepositoryCreateOneProductAsync? result = await _productRepository.createOneProductAsync(_mapper.Map<IProductRepositoryCreateOneProductAsync>(product));
			if (result is null)
			{
				//kayıt başarısız BadRequestException Dönelim
				return new BadRequestException("kayıt başarısız oldu");
			}
			//kayıt başarılı OkException Dönelim
			return new OkException<IProductServiceCreateProduct>("kayıt başarılı", _mapper.Map<IProductServiceCreateProduct>(result));
		}

		private async Task<bool> CheckIsAlreadyProductInDb(string barcodeNumber, int marketId)
		{
			IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsync? checkIsAlreadyProductInDb = await _productRepository.getOneProductByBarcodeNumberAndMarketIdAsync(barcodeNumber, marketId);
			return checkIsAlreadyProductInDb is not null;
		}


	}
}
