using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.IOrderService;

namespace Business.Abstracts.Order
{
	public interface IOrderService
	{
		Task<string> createOrderAsync(List<string> productIds);

		Task<IOrderServiceGetAllOrdersAsyncResponse> getAllOrdersAsync();

		Task<List<IOrderServiceGetOrdersByOrderIdAsyncResponse>> getOrdersByOrderIdAsync(string orderId);

		Task<IOrderServiceGetOrderByRowIdAsyncResponse> getOrderByRowIdAsync(int rowId);
		Task<IOrderServiceUpdateOrderAsyncResponse> updateOrderAsync(IOrderServiceUpdateOrderAsyncRequest order);

		Task<bool> deleteOrderbyRowIdAsync(int rowId);

		Task<string> deleteOrdersByOrderIdAsync(string OrderId);



	}
}
