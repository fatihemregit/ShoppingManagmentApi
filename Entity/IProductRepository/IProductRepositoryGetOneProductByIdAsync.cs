﻿namespace Entity.IProductRepository
{
	public class IProductRepositoryGetOneProductByIdAsync
	{
		public string BarcodeNumber { get; set; }

		public string Id { get; set; }

		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public int MarketId { get; set; }
	}
}