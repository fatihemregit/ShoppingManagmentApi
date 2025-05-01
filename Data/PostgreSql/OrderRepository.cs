using AutoMapper;
using Data.Abstracts.Order;
using Data.EfCore.Context;
using Data.PostgreSql.Context;
using Entity.Dto;
using Entity.IOrderRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PostgreSql
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContextPostgre _context;
		private readonly IMapper _mapper;

		public OrderRepository(ApplicationDbContextPostgre context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<IOrderRepositoryCreateOrdersAsyncResponse>?> createOrdersAsync(List<IOrderRepositoryCreateOrdersAsyncRequest> orders)
		{
			List<OrderDto> orderDtos = _mapper.Map<List<OrderDto>>(orders);
			await _context.Orders.AddRangeAsync(orderDtos);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return null;
			}
			return _mapper.Map<List<IOrderRepositoryCreateOrdersAsyncResponse>>(orderDtos);

		}

		public async Task<List<IOrderRepositoryGetAllOrdersAsyncResponse>> getAllAsync()
		{
			List<OrderDto> ordersInDb = await _context.Orders.ToListAsync();
			return _mapper.Map<List<IOrderRepositoryGetAllOrdersAsyncResponse>>(ordersInDb);
		}

		public async Task<List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>?> getOrdersByOrderIdAsync(string orderId)
		{
			List<OrderDto> ordersInDbwithOrderId = await _context.Orders.Where(o => o.OrderId == orderId).ToListAsync();
			if (ordersInDbwithOrderId.Count <= 0)
			{
				return null;
			}
			return _mapper.Map<List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>>(ordersInDbwithOrderId);
		}

		public async Task<IOrderRepositoryGetOneOrderByRowIdAsyncResponse?> getOneOrderByRowIdAsync(int RowId)
		{
			OrderDto? orderInDbWithRowId = await _context.Orders.Where(o => o.RowId == RowId).SingleOrDefaultAsync();
			if (orderInDbWithRowId is null)
			{
				return null;
			}
			return _mapper.Map<IOrderRepositoryGetOneOrderByRowIdAsyncResponse>(orderInDbWithRowId);
		}

		public async Task<IOrderRepositoryUpdateOneOrderAsyncResponse?> updateOneOrderAsync(IOrderRepositoryUpdateOneOrderAsyncRequest order)
		{
			OrderDto? foundOrderDto = await _context.Orders.Where(o => o.RowId == order.RowId).SingleOrDefaultAsync();
			if (foundOrderDto is null)
			{
				return null;
			}
			foundOrderDto.OrderId = order.OrderId;
			foundOrderDto.ProductId = order.ProductId;
			foundOrderDto.ProductPrice = order.ProductPrice;
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return null;
			}
			return _mapper.Map<IOrderRepositoryUpdateOneOrderAsyncResponse>(foundOrderDto);

		}

		public async Task<bool> deleteOneOrderbyRowIdAsync(int RowId)
		{
			//şimdilik direkt siliyoruz.daha sonrasında safe delete eklenecek
			OrderDto? foundOrderDto = await _context.Orders.Where(o => o.RowId == RowId).SingleOrDefaultAsync();
			if (foundOrderDto is null)
			{
				return false;
			}
			_context.Orders.Remove(foundOrderDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return false;
			}
			return true;

		}

		public async Task<bool> deleteOrdersByOrderIdAsync(string orderId)
		{
			//şimdilik direkt siliyoruz.daha sonrasında safe delete eklenecek
			List<OrderDto> foundOrderDtos = await _context.Orders.Where(o => o.OrderId == orderId).ToListAsync();
			if (foundOrderDtos.Count <= 0)
			{
				return false;
			}
			_context.Orders.RemoveRange(foundOrderDtos);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				return false;
			}
			return true;

		}
	}
}
