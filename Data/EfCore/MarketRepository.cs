﻿using AutoMapper;
using Data.Abstracts.Market;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.IMarketRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class MarketRepository:IMarketRepository
	{

		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public MarketRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IMarketRepositoryCreateOneMarketAsync?> createOneMarketAsync(IMarketRepositoryCreateOneMarketAsync market)
		{
			await _context.Markets.AddAsync(_mapper.Map<MarketDto>(market));
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return null;
			}
			return market;
		}

		public async Task<List<IMarketRepositoryGetAllAsync>> getAllAsync()
		{
			List<MarketDto> marketsinDb = await _context.Markets.ToListAsync();
			return _mapper.Map<List<IMarketRepositoryGetAllAsync>>(marketsinDb);
		}

		public async Task<IMarketRepositoryGetOneMarketByIdAsync?> getOneMarketByIdAsync(int id)
		{
			MarketDto? foundMarketById = await _context.Markets.Where(m => m.Id == id).SingleOrDefaultAsync();
			if (foundMarketById is null)
			{
				return null;
			}
			return _mapper.Map<IMarketRepositoryGetOneMarketByIdAsync>(foundMarketById);
		}

		public async Task<IMarketRepositoryUpdateOneMarketAsync?> updateOneMarketAsync(IMarketRepositoryUpdateOneMarketAsync market)
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
			return market;
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
