using Entity.Dto;
using Entity.IOrderRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts.Order
{
	public interface IOrderRepository
	{

		//Create
		Task<IOrderRepositoryCreateOneOrderAsyncResponse?> createOneOrderAsync(IOrderRepositoryCreateOneOrderAsyncRequest order);

		//Read
		Task<List<IOrderRepositoryGetAllOrdersAsyncResponse>> getAllAsync();
		Task<List<IOrderRepositoryGetOrdersByOrderIdAsyncResponse>?> getOrdersByOrderIdAsync(string orderId);
		Task<IOrderRepositoryGetOneOrderByRowIdAsyncResponse?> getOneOrderByRowIdAsync(int RowId);

		//Update
		Task<IOrderRepositoryUpdateOneOrderAsyncResponse?> updateOneOrderAsync(IOrderRepositoryUpdateOneOrderAsyncRequest order);
		//Delete
		Task<bool> deleteOneOrderbyRowIdAsync(int RowId);
		Task<bool> deleteOrdersByOrderIdAsync(string orderId);



	}


}
