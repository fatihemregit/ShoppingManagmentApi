﻿namespace Entity.IOrderService
{
	public class IOrderServiceGetOrdersByOrderIdAsyncResponse
	{
		public string OrderId { get; set; }

		public string ProductId { get; set; }

		public decimal ProductPrice { get; set; }
	}
}