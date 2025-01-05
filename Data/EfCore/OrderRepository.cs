using AutoMapper;
using Data.Abstracts.Order;
using Data.EfCore.Config;
using Data.EfCore.Context;
using Entity.Dto;
using Entity.IOrderRepository;

using Microsoft.EntityFrameworkCore;
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
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public OrderRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<IOrderRepositoryCreateOneOrderAsyncResponse?> createOneOrderAsync(IOrderRepositoryCreateOneOrderAsyncRequest order)
		{
			OrderDto orderDto = _mapper.Map<OrderDto>(order);

			await _context.Orders.AddAsync(orderDto);
			int result = await _context.SaveChangesAsync();
			if (result <= 0)
			{ 
				return null;
			}
			return _mapper.Map<IOrderRepositoryCreateOneOrderAsyncResponse>(orderDto);
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
			OrderDto? foundOrderDto =  await _context.Orders.Where(o => o.RowId == order.RowId).SingleOrDefaultAsync();
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

	

		


		

		
		//public async Task<string?> CreateOrderAsync(List<string> productIds)
		//{
		//	//acaba bu işlemleri business katmanında mı yapsak
		//	string? orderId = null;

		//          foreach (string item in productIds)
		//          {
		//		//found a product dto
		//		ProductDto? foundProductDto = awit _context.Products.Where(p => p.Id == item).SingleOrDefaultAsync();
		//		if(foundProductDto is null)a
		//		{
		//			return null;
		//		}
		//		OrderDto orderDto = new OrderDto();
		//		orderDto.ProductId = foundProductDto.Id;
		//		orderDto.ProductPrice = foundProductDto.Price;
		//		if (orderId is null)
		//		{
		//			var idGenerator = new CustomIdGeneratorForOrderDto();
		//			orderId = idGenerator.Next(_context.Entry(orderDto));
		//		}
		//		orderDto.OrderId = orderId;
		//		_context.Orders.Add(orderDto);
		//          }
		//	int result = await _context.SaveChangesAsync();
		//	if (result <= 0)
		//	{
		//		return null;
		//	}
		//	return orderId;
		//      }
	}
}
