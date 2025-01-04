using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
	[Table(name:"Order")]
	public class OrderDto
	{
		[Key]
        public int RowId { get; set; }

        public string OrderId { get; set; }

        public string ProductId { get; set; }

        public ProductDto Product { get; set; }
        public decimal ProductPrice { get; set; }

    }
}
