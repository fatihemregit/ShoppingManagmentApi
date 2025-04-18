﻿namespace Entity.IProductService
{
	public class IProductServiceCreateProductAsyncRequest
	{
		public string BarcodeNumber { get; set; }

		public string ProductName { get; set; }

		public decimal Price { get; set; }

		public int MarketId { get; set; }
	}
}