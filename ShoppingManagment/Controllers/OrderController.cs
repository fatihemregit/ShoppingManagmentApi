using AutoMapper;
using Business.Abstracts.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingManagment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{

        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;



		public OrderController(IMapper mapper, IOrderService orderService)
		{
			_mapper = mapper;
			_orderService = orderService;
		}

		[HttpPost()]
		public async Task<IActionResult> CreateOrder(List<string> ProductIds)
		{ 
			string orderServiceResponse = await _orderService.createOrderAsync(ProductIds);
			string marketControllerResponse = orderServiceResponse;
			return Ok(marketControllerResponse);
		}

	}
}
