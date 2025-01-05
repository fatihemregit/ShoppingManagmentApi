namespace Entity.IOrderService
{
	public class IOrderServiceGetOrderByRowIdAsyncResponse
	{
		public int RowId { get; set; }

		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}