namespace Entity.IProductService
{
	public class IProductServiceUpdateProductRequest
	{
		public string Id { get; set; }
		public string ProductName { get; set; }

		public decimal Price { get; set; }

	}
}