namespace Entity.IOrderRepository
{
	public class IOrderRepositoryCreateOrdersAsyncRequest
	{
		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}