using AutoMapper;
using Data.Abstracts.Market;
using Entity.IMarketRepository;
using Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Market
{
	public class MarketService
	{
		private readonly IMarketRepository _repository;
		private readonly IMapper _mapper;

		public MarketService(IMarketRepository marketRepository, IMapper mapper)
		{
			_repository = marketRepository;
			_mapper = mapper;
		}


		//Create Start

		private async Task<bool> checkisAlreadyMarketInDb(string marketName)
		{
			//null check
			if (marketName is null)
			{
				throw new BadRequestException("marketName parametresi null olamaz");
			}
			IMarketRepositoryGetOneMarketByNameAsyncResponse result =  await _repository.getOneMarketByNameAsync(marketName);
			return true;
		}

		public async Task<IMarketServiceCreateMarketAsyncResponse> createMarketAsync(IMarketServiceCreateMarketAsyncRequest market)
		{
			//null check
			if (market is null)
			{ 
				throw new BadRequestException("market parametresi null olamaz");
			}
			//daha önce böyle bir market var mı onun kontrolü
			bool CheckisAlreadyMarketInDb =  await checkisAlreadyMarketInDb(market.MarketName);
			if (CheckisAlreadyMarketInDb)
			{
				throw new ConflictException("bu ürün zaten daha önceden kaydedilmiş");
			}
			//yeni market oluşturma
			IMarketRepositoryCreateOneMarketAsyncResponse result = await _repository.createOneMarketAsync(_mapper.Map<IMarketRepositoryCreateOneMarketAsyncRequest>(market));
			//oluşturulan marketi dönme
			return _mapper.Map<IMarketServiceCreateMarketAsyncResponse>(result);



		}
		//Create End


	}
}
