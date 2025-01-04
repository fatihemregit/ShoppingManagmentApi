namespace Entity.IOrderRepository
{
	public class IOrderRepositoryCreateOneOrderAsyncRequest
	{
		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}