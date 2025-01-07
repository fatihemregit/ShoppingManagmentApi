

namespace Entity.IOrderRepository
{
	public class IOrderRepositoryCreateOrdersAsyncResponse
	{
		public int RowId { get; set; }

		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}