using AutoMapper;
using Data.Abstracts.Product;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.Exceptions;
using Entity.IProductRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class ProductRepository:IProductRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public ProductRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}



		public async Task<IProductRepositoryCreateOneProductAsyncResponse> createOneProductAsync(IProductRepositoryCreateOneProductAsyncRequest product)
		{
			ProductDto productDto = _mapper.Map<ProductDto>(product);
			await _context.Products.AddAsync(productDto);
			int result =  await _context.SaveChangesAsync();
			if (result <= 0)
			{
				//unsuccess
				throw new BadRequestException("Yeni Ürün Ekleme İşlemi Başarısız");
			}
			//sucess
			return _mapper.Map<IProductRepositoryCreateOneProductAsyncResponse>(productDto);
		}

		public async Task<List<IProductRepositoryGetAllAsyncResponse>> getAllAsync()
		{
			List<ProductDto> productsindb = await _context.Products.ToListAsync();
			return _mapper.Map<List<IProductRepositoryGetAllAsyncResponse>>(productsindb);
		}

		public async Task<IProductRepositoryGetOneProductByIdAsyncResponse> getOneProductByIdAsync(string id)
		{
			ProductDto? productinDbWithId = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
			if (productinDbWithId is null)
			{
				throw new NotFoundException($"{id} id li ürün bulunamadı");
			}
			return _mapper.Map<IProductRepositoryGetOneProductByIdAsyncResponse>(productinDbWithId);

		}

		public async Task<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse> getOneProductByBarcodeNumberAndMarketIdAsync(string barcodeNumber,int marketId)
		{
			ProductDto? productinDbWithBarcodeNumberandMarketId = await _context.Products.Where(p => p.BarcodeNumber == barcodeNumber && p.MarketId == marketId).SingleOrDefaultAsync();
			if (productinDbWithBarcodeNumberandMarketId is null)
			{
				throw new NotFoundException($"barcode number i {barcodeNumber} olan,market id si {marketId} olan ürün bulunamadı");
			}
			return _mapper.Map<IProductRepositoryGetOneProductByBarcodeNumberAndMarketIdAsyncResponse>(productinDbWithBarcodeNumberandMarketId);
		}

		public async Task<IProductRepositoryUpdateOneProductAsyncResponse> updateOneProductAsync(IProductRepositoryUpdateOneProductAsyncRequest product)
		{
			ProductDto? foundProductwithIdAndMarketId = await _context.Products.Where(p => p.Id == product.Id).SingleOrDefaultAsync();
			if (foundProductwithIdAndMarketId is null)
			{
				throw new NotFoundException($"{product.Id} id li ürün bulunamadı");
			}

			foundProductwithIdAndMarketId.ProductName = product.ProductName;
			foundProductwithIdAndMarketId.Price = product.Price;
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				throw new BadRequestException("ürün güncelleme başarısız");
			}
			return _mapper.Map<IProductRepositoryUpdateOneProductAsyncResponse>(foundProductwithIdAndMarketId);

		}

		public async Task<bool> deleteOneProductbyIdAsync(string id)
		{
			//daha sonrasında safe delete eklenecek ama şimdilik direkt siliyoruz
			ProductDto? foundProdcutwithId = await _context.Products.Where(p => p.Id == id).SingleOrDefaultAsync();
			if (foundProdcutwithId is null)
			{
				throw new NotFoundException($"{id} id li ürün bulunamadı");
			}
			_context.Products.Remove(foundProdcutwithId);
			int result = await _context.SaveChangesAsync();
			if (result <= 0) {
				throw new BadRequestException($"silme işlemi başarısız");
			}
			return true;
		}


	}
}
