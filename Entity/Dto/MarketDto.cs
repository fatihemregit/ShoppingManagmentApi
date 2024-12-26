using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Dto
{
	[Table(name: "Market")]
	public class MarketDto
	{
        public int Id { get; set; }

        public string MarketName { get; set; }

		public ICollection<ProductDto> Products { get; set; }
	}
}
