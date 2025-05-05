using AutoMapper;
using Data.Abstracts.Order;
using Data.EfCore.Config;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.IOrderRepository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore
{
	public class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContextSqlServer _context;
		private readonly IMapper _mapper;
		private readonly ILogger<OrderRepository> _logger;

		public OrderRepository(ApplicationDbContextSqlServer context, IMapper mapper, ILogger<OrderRepository> logger)
		{
			_context = context;
			_mapper = mapper;
			_logger = logger;
		}

		public async Task<List<IOrderRepositoryCreateOrdersAsyncResponse>?> createOrdersAsync(List<IOrderRepositoryCreateOrdersAsyncRequest> orders)
		{
			List<OrderDto> orderDtos = _mapper.Map<List<OrderDto>>(orders);
			await _context.Orders.AddRangeAsync(orderDtos);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug("sipariş oluşturulamadı");
				return null;
			}
			_logger.LogInformation($"sipariş oluşturuldu(sipariş id :{orderDtos.First().OrderId})");
			return _mapper.Map<List<IOrderRepositoryCreateOrdersAsyncResponse>>(orderDtos);

		}

		public async Task<List<IOrderRepositoryGetAllOrdersAsyncResponse>> getAllAsync()
		{
			List<OrderDto> ordersInDb = await _context.Orders.ToListAsync();
			_logger.LogInformation($"siparişler getirildi");
			return _mapper.Map<List<IOrderRepositoryGetAllOrdersAsyncResponse>>(ordersInDb);
		}

		public async Task<List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>?> getOrdersByOrderIdAsync(string orderId)
		{
			List<OrderDto> ordersInDbwithOrderId = await _context.Orders.Where(o => o.OrderId == orderId).ToListAsync();
			if (ordersInDbwithOrderId.Count <= 0)
			{
				_logger.LogDebug($"sipariş bulunamadı {orderId}");
				return null;
			}
			_logger.LogInformation($"siparişler getirildi(row id {orderId})");
			return _mapper.Map<List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>>(ordersInDbwithOrderId);
		}

		public async Task<IOrderRepositoryGetOneOrderByRowIdAsyncResponse?> getOneOrderByRowIdAsync(int RowId)
		{
			OrderDto? orderInDbWithRowId = await _context.Orders.Where(o => o.RowId == RowId).SingleOrDefaultAsync();
			if (orderInDbWithRowId is null)
			{
				_logger.LogDebug($"sipariş bulunamadı row id : {RowId}");
				return null;
			}
			_logger.LogInformation($"sipariş getirildi(order Id : {orderInDbWithRowId.OrderId})");
			return _mapper.Map<IOrderRepositoryGetOneOrderByRowIdAsyncResponse>(orderInDbWithRowId);
		}

		public async Task<IOrderRepositoryUpdateOneOrderAsyncResponse?> updateOneOrderAsync(IOrderRepositoryUpdateOneOrderAsyncRequest order)
		{
			OrderDto? foundOrderDto =  await _context.Orders.Where(o => o.RowId == order.RowId).SingleOrDefaultAsync();
			if (foundOrderDto is null)
			{
				_logger.LogDebug($"sipariş bulunamadı row id : {order.RowId}");
				return null;
			}
			foundOrderDto.OrderId = order.OrderId;
			foundOrderDto.ProductId = order.ProductId;
			foundOrderDto.ProductPrice = order.ProductPrice;
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug($"sipariş güncellenemedi (row id : ${order.RowId})");
				return null;
			}
			_logger.LogInformation($"sipariş güncellendi (row id : ${order.RowId})");
			return _mapper.Map<IOrderRepositoryUpdateOneOrderAsyncResponse>(foundOrderDto);

		}

		public async Task<bool> deleteOneOrderbyRowIdAsync(int RowId)
		{
			//şimdilik direkt siliyoruz.daha sonrasında safe delete eklenecek
			OrderDto? foundOrderDto = await _context.Orders.Where(o => o.RowId == RowId).SingleOrDefaultAsync();
			if (foundOrderDto is null)
			{
				_logger.LogDebug($"sipariş bulunamadı row id : {RowId}");
				return false;
			}
			_context.Orders.Remove(foundOrderDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogDebug($"sipariş silinemedi (row id : ${RowId})");
				return false;
			}
			_logger.LogInformation($"sipariş silindi (row id : ${RowId})");
			return true;

		}

		public async Task<bool> deleteOrdersByOrderIdAsync(string orderId)
		{
			//şimdilik direkt siliyoruz.daha sonrasında safe delete eklenecek
			List<OrderDto> foundOrderDtos = await _context.Orders.Where(o => o.OrderId == orderId).ToListAsync();
			if (foundOrderDtos.Count <= 0)
			{
				_logger.LogDebug($"siparişler silinemedi (order Id : ${orderId})");

				return false;
			}
			_context.Orders.RemoveRange(foundOrderDtos);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{
				_logger.LogInformation($"siparişler silindi (order Id : ${orderId})");

				return false;
			}
			return true;

		}
	}
}
