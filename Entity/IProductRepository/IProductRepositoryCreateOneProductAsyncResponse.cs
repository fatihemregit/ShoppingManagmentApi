using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.IProductRepository
{
	public class IProductRepositoryCreateOneProductAsyncResponse
	{

		//bu field e gerek var mı değerlendir
		public string Id { get; set; }
		public string BarcodeNumber { get; set; }
		public string ProductName { get; set; }

		public decimal Price { get; set; }

		public int MarketId { get; set; }
	}
}
