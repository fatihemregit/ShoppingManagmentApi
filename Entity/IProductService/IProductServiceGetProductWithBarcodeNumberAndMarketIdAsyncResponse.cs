namespace Entity.IProductService
{
	public class IProductServiceGetProductWithBarcodeNumberAndMarketIdAsyncResponse
	{
		public string BarcodeNumber { get; set; }
		public string Id { get; set; }

		public string ProductName { get; set; }
		public decimal Price { get; set; }

	}
}