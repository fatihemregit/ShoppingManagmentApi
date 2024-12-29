using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IProductService
{
	public class IProductServiceUpdateProductResponse
	{
		public string BarcodeNumber { get; set; }
		public string Id { get; set; }
		public string ProductName { get; set; }
		public decimal Price { get; set; }
		public int MarketId { get; set; }
	}
}
