using AutoMapper;
using Business.Abstracts.Order;
using Business.Utils.Functions;
using Data.Abstracts.Order;
using Entity.IOrderService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes.Order
{
	public class OrderService : IOrderService
	{

		private readonly IMapper _mapper;
		private readonly IOrderRepository _orderRepository;


		public OrderService(IMapper mapper, IOrderRepository orderRepository)
		{
			_mapper = mapper;
			_orderRepository = orderRepository;
		}


		public async Task<string> createOrderAsync(List<string> productIds)
		{

			return "";
		}

		public Task<IOrderServiceGetAllOrdersAsyncResponse> getAllOrdersAsync()
		{
			throw new NotImplementedException();
		}

		public Task<List<IOrderServiceGetOrdersByOrderIdAsyncResponse>> getOrdersByOrderIdAsync(string orderId)
		{
			throw new NotImplementedException();
		}

		public Task<IOrderServiceGetOrderByRowIdAsyncResponse> getOrderByRowIdAsync(int rowId)
		{
			throw new NotImplementedException();
		}

		public Task<IOrderServiceUpdateOrderAsyncResponse> updateOrderAsync(IOrderServiceUpdateOrderAsyncRequest order)
		{
			throw new NotImplementedException();
		}

		public Task<bool> deleteOrderbyRowIdAsync(int rowId)
		{
			throw new NotImplementedException();
		}

		public Task<string> deleteOrdersByOrderIdAsync(string OrderId)
		{
			throw new NotImplementedException();
		}



		

		

		
	}
}
