using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{

    [Table(name: "Product")]
	public class ProductDto
	{

        public string BarcodeNumber { get; set; }

        //this prop type is string because.I want to create custom Id(eg : "prd...")
        public string Id { get; set; }

        public string ProductName { get; set; }

		[Column(TypeName = "decimal(18, 2)")]
		public decimal Price { get; set; }

		//relation to MarketDto
		public int MarketId { get; set; }
		public MarketDto Market { get; set; }

	}
}
