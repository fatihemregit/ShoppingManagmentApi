namespace Entity.IProductRepository
{
	public class IProductRepositoryUpdateOneProductAsyncRequest
	{
		public string Id { get; set; }

		public string ProductName { get; set; }
		public decimal Price { get; set; }
	}
}