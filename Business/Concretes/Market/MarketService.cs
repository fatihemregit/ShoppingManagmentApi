using AutoMapper;
using Data.Abstracts.Market;
using Entity.IMarketRepository;
using Entity.IMarketService;
using Entity.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts.Market;
using Business.Utils.Functions;
//using Business.Abstracts.Logger;

namespace Business.Concretes.Market
{
	public class MarketService : IMarketService
	{
		private readonly IMarketRepository _repository;
		private readonly IMapper _mapper;
		//private readonly ILoggerService _logger;

		public MarketService(IMarketRepository marketRepository, IMapper mapper/*, ILoggerService logger*/)
		{
			_repository = marketRepository;
			_mapper = mapper;
			//_logger = logger;
		}


		//Create Start

		private async Task<bool> checkisAlreadyMarketInDb(string marketName)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(new { marketName = marketName }))
			{
				throw new BadRequestException("marketName parametresi null olamaz");
			}
			//eğer ürün yoksa result null gelir
			IMarketRepositoryGetOneMarketByNameAsyncResponse? result = await _repository.getOneMarketByNameAsync(marketName);
			return result is not null;
		}

		public async Task<IMarketServiceCreateMarketAsyncResponse> createMarketAsync(IMarketServiceCreateMarketAsyncRequest market)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(market))
			{
				//_logger.unSucessInBusinessLayer("market parametresi null olamaz", market);
				throw new BadRequestException("market parametresi null olamaz");
			}
			//daha önce böyle bir market var mı onun kontrolü
			if (await checkisAlreadyMarketInDb(market.MarketName))
			{
				//_logger.unSucessInBusinessLayer("bu market zaten daha önceden kaydedilmiş", market);
				throw new ConflictException("bu market zaten daha önceden kaydedilmiş");
			}
			//yeni market oluşturma
			IMarketRepositoryCreateOneMarketAsyncResponse? result = await _repository.createOneMarketAsync(_mapper.Map<IMarketRepositoryCreateOneMarketAsyncRequest>(market));
			//market oluşturma başarısız
			if (result is null)
			{
				//_logger.unSucessInBusinessLayer("market ekleme başarısız",market);
				throw new BadRequestException("market ekleme başarısız");
			}
			//market oluşturma başarılı
			//oluşturulan marketi dönme
			//_logger.sucessInBusinessLayer("market ekleme başarılı",result);
			return _mapper.Map<IMarketServiceCreateMarketAsyncResponse>(result);

		}
		//Create End

		//Read Start
		public async Task<List<IMarketServiceGetAllMarketsAsyncResponse>> getAllMarketsAsync()
		{
			List<IMarketRepositoryGetAllAsyncResponse> result = await _repository.getAllAsync();
			return _mapper.Map<List<IMarketServiceGetAllMarketsAsyncResponse>>(result);
		}

		public async Task<IMarketServiceGetMarketByIdAsyncResponse> getMarketByIdAsync(int id)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(new { id = id }))
			{
				//_logger.unSucessInBusinessLayer("id parametresi null olamaz", new { id = id });
				throw new BadRequestException("id parametresi null olamaz");
			}

			//eğer verilen id ye göre market yoksa null gelir
			IMarketRepositoryGetOneMarketByIdAsyncResponse? result = await _repository.getOneMarketByIdAsync(id);
			if (result is null)
			{
				//id ye göre market bulunamadı
				//_logger.unSucessInBusinessLayer($"{id} id li market bulunamadı",new {id = id});
				throw new NotFoundException($"{id} id li market bulunamadı");
			}
			//id ye göre market var marketi dönelim
			//_logger.sucessInBusinessLayer($"{id} id li market bulundu",result);
			return _mapper.Map<IMarketServiceGetMarketByIdAsyncResponse>(result);
		}
		//Read End

		//Update Start
		public async Task<IMarketServiceUpdateMarketAsyncResponse> updateMarketAsync(IMarketServiceUpdateMarketAsyncRequest market)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(market))
			{
				//_logger.unSucessInBusinessLayer("market parametresi null olamaz",market);
				throw new BadRequestException("market parametresi null olamaz");

			}
			//eğer market güncellleme başarısız olursa result null gelir
			IMarketRepositoryUpdateOneMarketAsyncResponse? result = await _repository.updateOneMarketAsync(_mapper.Map<IMarketRepositoryUpdateOneMarketAsyncRequest>(market));
			if (result is null)
			{
				//_logger.unSucessInBusinessLayer("market güncelleme başarısız", market);
				throw new BadRequestException("market güncelleme başarısız");
			}
			//_logger.sucessInBusinessLayer("market güncelleme başarılı",result);
			return _mapper.Map<IMarketServiceUpdateMarketAsyncResponse>(result);

		}
		//Update End

		//Delete Start

		public async Task<bool> deleteMarketAsync(int id)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(new { id = id }))
			{
				//_logger.unSucessInBusinessLayer("id parametresi null olamaz", new { id = id });
				throw new BadRequestException("id parametresi null olamaz");
			}
			//eğer market silme işlemi başarısız ise result 'false' gelir
			bool result = await _repository.deleteOneMarketByIdAsync(id);
			if (!result)
			{
				//_logger.unSucessInBusinessLayer("market silme başarısız", new { id = id });
				throw new BadRequestException("market silme başarısız");
			}
			return result;


		}
		//Delete End

	}
}
