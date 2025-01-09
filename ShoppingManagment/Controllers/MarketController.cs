using AutoMapper;
using Business.Abstracts.Market;
using Entity.IMarketService;
using Entity.MarketController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ShoppingManagment.Controllers
{
	[EnableRateLimiting(policyName: "marketController")]
	[Route("api/[controller]")]
	[ApiController]
	public class MarketController : ControllerBase
	{
		private readonly IMarketService _service;
		private readonly IMapper _mapper;

		public MarketController(IMarketService marketService, IMapper mapper)
		{
			_service = marketService;
			_mapper = mapper;
		}

		//Create
		[HttpPost()]
		public async Task<IActionResult> createMarketAsync(MarketControllerCreateMarketAsyncRequest market)
		{
			IMarketServiceCreateMarketAsyncResponse marketServiceResponse = await _service.createMarketAsync(_mapper.Map<IMarketServiceCreateMarketAsyncRequest>(market));
			MarketControllerCreateMarketAsyncResponse marketControllerResponse = _mapper.Map<MarketControllerCreateMarketAsyncResponse>(marketServiceResponse);
			return Ok(marketControllerResponse);
		}
		//Read
		[HttpGet()]
		public async Task<IActionResult> getAllMarketsAsync()
		{
			List<IMarketServiceGetAllMarketsAsyncResponse> marketServiceResponse = await _service.getAllMarketsAsync();
			List<MarketControllerGetAllMarketsAsyncResponse> marketControllerResponse = _mapper.Map<List<MarketControllerGetAllMarketsAsyncResponse>>(marketServiceResponse);
			return Ok(marketControllerResponse);
		}
		[HttpGet("{id:int}")]
		public async Task<IActionResult> getMarketByIdAsync([FromRoute(Name = "id")]int id)
		{
			IMarketServiceGetMarketByIdAsyncResponse marketServiceResponse = await _service.getMarketByIdAsync(id);
			MarketControllerGetMarketByIdAsyncResponse marketControllerResponse = _mapper.Map<MarketControllerGetMarketByIdAsyncResponse>(marketServiceResponse);
			return Ok(marketControllerResponse);
		}
		//Update

		[HttpPut()]
		public async Task<IActionResult> updateMarketAsync([FromBody]MarketControllerUpdateMarketAsyncRequest market)
		{
			IMarketServiceUpdateMarketAsyncResponse marketServiceResponse = await _service.updateMarketAsync(_mapper.Map<IMarketServiceUpdateMarketAsyncRequest>(market));
			MarketControllerUpdateMarketAsyncResponse marketControllerResponse = _mapper.Map<MarketControllerUpdateMarketAsyncResponse>(marketServiceResponse);
			return Ok(marketControllerResponse);
		}

		//Delete
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> deleteMarketAsync([FromRoute(Name = "id")] int id)
		{ 
			bool marketServiceResponse = await _service.deleteMarketAsync(id);
			bool marketControllerResponse = marketServiceResponse;
			return Ok(marketControllerResponse);
		}

		[HttpGet("rateTest")]
		public IActionResult rateTest()
		{
			return Ok();
		}




	}
}
