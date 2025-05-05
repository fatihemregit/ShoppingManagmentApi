using AutoMapper;
//using Data.Abstracts.Logger;
using Data.Abstracts.Market;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.Exceptions;

using Entity.IMarketRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class MarketRepository : IMarketRepository
	{
		//daha sonrasında veritabanından kaynaklı hataları da loglayalım

		private readonly ApplicationDbContextSqlServer _context;
		private readonly IMapper _mapper;
		private readonly ILogger<MarketRepository> _logger;

		public MarketRepository(ApplicationDbContextSqlServer context, IMapper mapper, ILogger<MarketRepository> logger)
		{
			_context = context;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<IMarketRepositoryCreateOneMarketAsyncResponse?> createOneMarketAsync(IMarketRepositoryCreateOneMarketAsyncRequest market)
		{
			MarketDto marketDto = _mapper.Map<MarketDto>(market);
			await _context.Markets.AddAsync(marketDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug("yeni market ekleme başarısız");
				return null;
			}
			_logger.LogInformation("yeni market ekleme başarılı");
			return _mapper.Map<IMarketRepositoryCreateOneMarketAsyncResponse>(marketDto);
		}

		public async Task<List<IMarketRepositoryGetAllAsyncResponse>> getAllAsync()
		{
			List<MarketDto> marketsinDb = await _context.Markets.ToListAsync();
			_logger.LogInformation("tüm marketleri listeleme başarılı");
			return _mapper.Map<List<IMarketRepositoryGetAllAsyncResponse>>(marketsinDb);
		}

		public async Task<IMarketRepositoryGetOneMarketByIdAsyncResponse?> getOneMarketByIdAsync(int id)
		{
			MarketDto? foundMarketById = await _context.Markets.Where(m => m.Id == id).SingleOrDefaultAsync();
			if (foundMarketById is null)
			{
				_logger.LogDebug($"market bulunamadı(market id : {id})");
				return null;
			}
			_logger.LogInformation("market bulundu");
			return _mapper.Map<IMarketRepositoryGetOneMarketByIdAsyncResponse>(foundMarketById);
		}

		public async Task<IMarketRepositoryGetOneMarketByNameAsyncResponse?> getOneMarketByNameAsync(string MarketName)
		{
			MarketDto? foundMarketByName = await _context.Markets.Where(m => m.MarketName == MarketName).SingleOrDefaultAsync();
			if (foundMarketByName is null)
			{
				_logger.LogDebug($"market bulunamadı(market adı : {MarketName})");
				return null;
			}
			_logger.LogInformation("market bulundu");
			return _mapper.Map<IMarketRepositoryGetOneMarketByNameAsyncResponse>(foundMarketByName);

		}


		public async Task<IMarketRepositoryUpdateOneMarketAsyncResponse?> updateOneMarketAsync(IMarketRepositoryUpdateOneMarketAsyncRequest market)
		{
			MarketDto? foundMarketDtowithId = await _context.Markets.Where(m => m.Id == market.Id).SingleOrDefaultAsync();
			if (foundMarketDtowithId is null)
			{
				_logger.LogDebug($"market bulunamadı(market id : {market.Id})");
				return null;
			}
			foundMarketDtowithId.MarketName = market.MarketName;
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug("market güncellenemedi");
				return null;
			}
			_logger.LogInformation("market güncellendi");
			return _mapper.Map<IMarketRepositoryUpdateOneMarketAsyncResponse>(foundMarketDtowithId);
		}

		public async Task<bool> deleteOneMarketByIdAsync(int id)
		{
			//daha sonrasında safe delete eklenecek ama şimdilik direkt siliyoruz
			MarketDto? foundMarketDtoWithId = await _context.Markets.Where(m => m.Id == id).SingleOrDefaultAsync();
			if (foundMarketDtoWithId is null)
			{
				_logger.LogDebug($"market bulunamadı(market id : {id})");
				return false;
			}
			_context.Markets.Remove(foundMarketDtoWithId);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug("market silinemedi");
				return false;
			}
			_logger.LogInformation("market silindi");
			return true;
		}


	}
}
