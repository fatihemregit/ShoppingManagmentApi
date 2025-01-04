using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IOrderRepository
{
	public class IOrderRepositoryGetOrdersByOrderIdAsyncResponse
	{
		public int RowId { get; set; }
		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}
