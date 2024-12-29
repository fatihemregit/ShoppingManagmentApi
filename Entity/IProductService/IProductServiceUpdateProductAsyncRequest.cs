namespace Entity.IProductService
{
	public class IProductServiceUpdateProductAsyncRequest
	{
		public string Id { get; set; }
		public string ProductName { get; set; }

		public decimal Price { get; set; }

	}
}