using AutoMapper;
using Data.Abstracts.Market;
using Data.EfCore.Context;
using Data.PostgreSql.Context;
using Entity.Dto;
using Entity.IMarketRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PostgreSql
{
	public class MarketRepository : IMarketRepository
	{
		private readonly ApplicationDbContextPostgre _context;
		private readonly IMapper _mapper;


		public MarketRepository(ApplicationDbContextPostgre context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IMarketRepositoryCreateOneMarketAsyncResponse?> createOneMarketAsync(IMarketRepositoryCreateOneMarketAsyncRequest market)
		{
			MarketDto marketDto = _mapper.Map<MarketDto>(market);
			await _context.Markets.AddAsync(marketDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{

				return null;
			}
			return _mapper.Map<IMarketRepositoryCreateOneMarketAsyncResponse>(marketDto);
		}

		public async Task<List<IMarketRepositoryGetAllAsyncResponse>> getAllAsync()
		{
			List<MarketDto> marketsinDb = await _context.Markets.ToListAsync();
			return _mapper.Map<List<IMarketRepositoryGetAllAsyncResponse>>(marketsinDb);
		}

		public async Task<IMarketRepositoryGetOneMarketByIdAsyncResponse?> getOneMarketByIdAsync(int id)
		{
			MarketDto? foundMarketById = await _context.Markets.Where(m => m.Id == id).SingleOrDefaultAsync();
			if (foundMarketById is null)
			{
				return null;
			}
			return _mapper.Map<IMarketRepositoryGetOneMarketByIdAsyncResponse>(foundMarketById);
		}

		public async Task<IMarketRepositoryGetOneMarketByNameAsyncResponse?> getOneMarketByNameAsync(string MarketName)
		{
			MarketDto? foundMarketByName = await _context.Markets.Where(m => m.MarketName == MarketName).SingleOrDefaultAsync();
			if (foundMarketByName is null)
			{
				return null;
			}
			return _mapper.Map<IMarketRepositoryGetOneMarketByNameAsyncResponse>(foundMarketByName);

		}


		public async Task<IMarketRepositoryUpdateOneMarketAsyncResponse?> updateOneMarketAsync(IMarketRepositoryUpdateOneMarketAsyncRequest market)
		{
			MarketDto? foundMarketDtowithId = await _context.Markets.Where(m => m.Id == market.Id).SingleOrDefaultAsync();
			if (foundMarketDtowithId is null)
			{
				return null;
			}
			foundMarketDtowithId.MarketName = market.MarketName;
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return null;
			}
			return _mapper.Map<IMarketRepositoryUpdateOneMarketAsyncResponse>(foundMarketDtowithId);
		}

		public async Task<bool> deleteOneMarketByIdAsync(int id)
		{
			//daha sonrasında safe delete eklenecek ama şimdilik direkt siliyoruz
			MarketDto? foundMarketDtoWithId = await _context.Markets.Where(m => m.Id == id).SingleOrDefaultAsync();
			if (foundMarketDtoWithId is null)
			{
				return false;
			}
			_context.Markets.Remove(foundMarketDtoWithId);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return false;
			}
			return true;
		}
	}
}
