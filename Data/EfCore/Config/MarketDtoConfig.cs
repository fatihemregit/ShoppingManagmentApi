using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Config
{
	public class MarketDtoConfig : IEntityTypeConfiguration<MarketDto>
	{
		public void Configure(EntityTypeBuilder<MarketDto> builder)
		{
			//adding to ready Data
			builder.HasData(
				new MarketDto() { Id = 1,MarketName = "Test Market"}
				);
		}
	}
}
