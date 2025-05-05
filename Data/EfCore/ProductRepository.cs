using AutoMapper;
using Data.Abstracts.Product;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.Exceptions;
using Entity.IProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContextSqlServer _context;
		private readonly IMapper _mapper;
		private readonly ILogger<ProductRepository> _logger;

		public ProductRepository(ApplicationDbContextSqlServer context, IMapper mapper, ILogger<ProductRepository> logger)
		{
			_context = context;
			_mapper = mapper;
			_logger = logger;
		}



		public async Task<IProductRepositoryCreateOneProductAsyncResponse?> createOneProductAsync(IProductRepositoryCreateOneProductAsyncRequest product)
		{
			ProductDto productDto = _mapper.Map<ProductDto>(product);
			productDto.CreatedDate = DateTime.Now.ToUniversalTime();
			productDto.ModifiedDate = DateTime.Now.ToUniversalTime();
			await _context.Products.AddAsync(productDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				//unsuccess
				_logger.LogDebug($"Ürün oluşturulamadı (Ürün Adı :{product.ProductName})");
				return null;
			}
			//sucess
			_logger.LogInformation($"Ürün oluşturuldu (ürün id : {productDto.Id})");
			return _mapper.Map<IProductRepositoryCreateOneProductAsyncResponse>(productDto);
		}

		public async Task<List<IProductRepositoryGetAllAsyncResponse>> getAllAsync()
		{
			List<ProductDto> productsindb = await _context.Products.ToListAsync();
			_logger.LogInformation("Ürünler listelendi");
			return _mapper.Map<List<IProductRepositoryGetAllAsyncResponse>>(productsindb);
		}

		public async Task<IProductRepositoryGetOneProductByIdAsyncResponse?> getOneProductByIdAsync(string id)
		{
			ProductDto? productinDbWithId = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
			if (productinDbWithId is null)
			{
				_logger.LogDebug($"Ürün bulunamadı (Ürün Id :{id})");
				return null;
			}
			_logger.LogInformation($"Ürün bulundu (Ürün Adı :{productinDbWithId.ProductName})");
			return _mapper.Map<IProductRepositoryGetOneProductByIdAsyncResponse>(productinDbWithId);

		}

		public async Task<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse?> getOneProductByBarcodeNumberAndMarketIdAsync(string barcodeNumber, int marketId)
		{
			ProductDto? productinDbWithBarcodeNumberandMarketId = await _context.Products.Where(p => p.BarcodeNumber == barcodeNumber && p.MarketId == marketId).SingleOrDefaultAsync();
			if (productinDbWithBarcodeNumberandMarketId is null)
			{
				_logger.LogDebug($"Ürün bulunamadı (Ürün Barkod Numarası :{barcodeNumber})");
				return null;
			}
			_logger.LogInformation($"ürün bulundu (Ürün Barkod Numarası : {barcodeNumber})");
			return _mapper.Map<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>(productinDbWithBarcodeNumberandMarketId);
		}

		public async Task<IProductRepositoryUpdateOneProductAsyncResponse?> updateOneProductAsync(IProductRepositoryUpdateOneProductAsyncRequest product)
		{
			ProductDto? foundProductwithIdAndMarketId = await _context.Products.Where(p => p.Id == product.Id).SingleOrDefaultAsync();
			if (foundProductwithIdAndMarketId is null)
			{
				return null;
			}

			foundProductwithIdAndMarketId.ProductName = product.ProductName;
			foundProductwithIdAndMarketId.Price = product.Price;
			foundProductwithIdAndMarketId.ModifiedDate = DateTime.Now.ToUniversalTime();
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug($"Ürün güncellenemedi (Ürün Id :{product.Id})");
				return null;
			}
			_logger.LogInformation($"Ürün güncellendi (Ürün Id :{product.Id})");
			return _mapper.Map<IProductRepositoryUpdateOneProductAsyncResponse>(foundProductwithIdAndMarketId);

		}

		public async Task<bool> deleteOneProductbyIdAsync(string id)
		{
			//daha sonrasında safe delete eklenecek ama şimdilik direkt siliyoruz
			ProductDto? foundProdcutwithId = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
			if (foundProdcutwithId is null)
			{
				_logger.LogDebug($"Ürün bulunamadı (Ürün Id :{id})");
				return false;
			}
			_context.Products.Remove(foundProdcutwithId);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug($"Ürün silinemedi (Ürün Id :{id})");
				return false;
			}
			_logger.LogInformation($"Ürün silindi (Ürün Id : {id})");
			return true;
		}


	}
}
