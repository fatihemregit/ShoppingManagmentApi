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

namespace Business.Concretes.Market
{
	public class MarketService:IMarketService
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
			if (HelpFullFunctions.nullCheckObjectProps(new {marketName = marketName}))
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
				throw new BadRequestException("market parametresi null olamaz");
			}
			//daha önce böyle bir market var mı onun kontrolü
			if (await checkisAlreadyMarketInDb(market.MarketName))
			{
				throw new ConflictException("bu market zaten daha önceden kaydedilmiş");
			}
			//yeni market oluşturma
			IMarketRepositoryCreateOneMarketAsyncResponse? result = await _repository.createOneMarketAsync(_mapper.Map<IMarketRepositoryCreateOneMarketAsyncRequest>(market));
			//market oluşturma başarısız
			if (result is null)
			{
				throw new BadRequestException("market ekleme başarısız");
			}
			//market oluşturma başarılı
			//oluşturulan marketi dönme
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
			if (HelpFullFunctions.nullCheckObjectProps(new {id = id}))
			{
				throw new BadRequestException("id parametresi null olamaz");
			}

			//eğer verilen id ye göre market yoksa null gelir
			IMarketRepositoryGetOneMarketByIdAsyncResponse? result = await _repository.getOneMarketByIdAsync(id);
			if (result is null)
			{
				//id ye göre market bulunamadı
				throw new NotFoundException($"{id} id li market bulunamadı");
			}
			//id ye göre market var marketi dönelim
			return _mapper.Map<IMarketServiceGetMarketByIdAsyncResponse>(result);
		}
		//Read End

		//Update Start
		public async Task<IMarketServiceUpdateMarketAsyncResponse> updateMarketAsync(IMarketServiceUpdateMarketAsyncRequest market)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(market))
			{
				throw new BadRequestException("market parametresi null olamaz");
			}
			//eğer market güncellleme başarısız olursa result null gelir
			IMarketRepositoryUpdateOneMarketAsyncResponse? result = await _repository.updateOneMarketAsync(_mapper.Map<IMarketRepositoryUpdateOneMarketAsyncRequest>(market));
			if (result is null)
			{
				throw new BadRequestException("market güncelleme başarısız");
			}
			return _mapper.Map<IMarketServiceUpdateMarketAsyncResponse>(result);

		}
		//Update End

		//Delete Start

		public async Task<bool> deleteMarketAsync(int id)
		{
			//null check
			if (HelpFullFunctions.nullCheckObjectProps(new {id = id}))
			{
				throw new BadRequestException("id parametresi null olamaz");
			}
			//eğer market silme işlemi başarısız ise result 'false' gelir
			bool result = await _repository.deleteOneMarketByIdAsync(id);
			if (!result)
			{
				throw new BadRequestException("market silme başarısız");
			}
			return result;


		}
		//Delete End

	}
}
