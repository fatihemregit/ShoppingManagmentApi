using AutoMapper;
using Business.Abstracts.Order;
using Entity.IOrderService;
using Entity.OrderController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace ShoppingManagment.Controllers
{
	[EnableRateLimiting(policyName: "orderController")]
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

		//Create
		[HttpPost()]
		public async Task<IActionResult> CreateOrderAsync(List<string> ProductIds)
		{
			string orderServiceResponse = await _orderService.createOrderAsync(ProductIds);
			string orderControllerResponse = orderServiceResponse;
			return Ok(orderControllerResponse);
		}

		//Read
		[HttpGet()]
		public async Task<IActionResult> getAllOrdersAsync()
		{
			List<IOrderServiceGetAllOrdersAsyncResponse> orderServiceResponse = await _orderService.getAllOrdersAsync();
			List<OrderControllerGetAllOrdersAsyncResponse> orderControllerResponse = _mapper.Map<List<OrderControllerGetAllOrdersAsyncResponse>>(orderServiceResponse);
			return Ok(orderControllerResponse);
		}
		[HttpGet("{orderId}")]
		public async Task<IActionResult> getOrdersByOrderIdAsync([FromRoute(Name = "orderId")] string orderId)
		{
			List<IOrderServiceGetOrdersByOrderIdAsyncResponse> orderServiceResponse = await _orderService.getOrdersByOrderIdAsync(orderId);
			List<OrderControllerGetOrdersByOrderIdAsyncResponse> orderControllerResponse = _mapper.Map<List<OrderControllerGetOrdersByOrderIdAsyncResponse>>(orderServiceResponse);
			return Ok(orderControllerResponse);
		}

		[HttpGet("{rowId:int}")]
		public async Task<IActionResult> getOrderByRowIdAsync([FromRoute(Name = "rowId")]int rowId)
		{
			IOrderServiceGetOrderByRowIdAsyncResponse orderServiceResponse =  await _orderService.getOrderByRowIdAsync(rowId);
			OrderControllerGetOrderByRowIdAsyncResponse orderControllerResponse = _mapper.Map<OrderControllerGetOrderByRowIdAsyncResponse>(orderServiceResponse);
			return Ok(orderControllerResponse);
		}

		//Update
		[HttpPut()]
		public async Task<IActionResult> updateOrderAsync(OrderControllerUpdateOrderAsyncRequest order)
		{
			IOrderServiceUpdateOrderAsyncResponse orderServiceResponse = await _orderService.updateOrderAsync(_mapper.Map<IOrderServiceUpdateOrderAsyncRequest>(order));
			OrderControllerUpdateOrderAsyncResponse orderControllerResponse = _mapper.Map<OrderControllerUpdateOrderAsyncResponse>(orderServiceResponse);
			return Ok(orderControllerResponse);
		}
		//Delete
		[HttpDelete("{rowId:int}")]
		public async Task<IActionResult> deleteOrderbyRowIdAsync([FromRoute(Name = "rowId")]int rowId)
		{
			bool orderServiceResponse = await _orderService.deleteOrderbyRowIdAsync(rowId);
			bool orderControllerResponse = orderServiceResponse;
			return Ok(orderControllerResponse);
		}
		[HttpDelete("{orderId}")]
		public async Task<IActionResult> deleteOrdersByOrderIdAsync([FromRoute(Name = "orderId")] string orderId)
		{
			bool orderServiceResponse = await _orderService.deleteOrdersByOrderIdAsync(orderId);
			bool orderControllerResponse = orderServiceResponse;
			return Ok(orderControllerResponse);
		}

		[HttpGet("rateTest")]
		public IActionResult rateTest()
		{
			return Ok();
		}

	}
}
