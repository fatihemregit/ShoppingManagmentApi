using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Config
{
	public class OrderDtoConfig : IEntityTypeConfiguration<OrderDto>
	{
		public void Configure(EntityTypeBuilder<OrderDto> builder)
		{
			//builder.Property(p => p.OrderId)
			//	.HasValueGenerator<CustomIdGeneratorForOrderDto>()
			//	.IsRequired();
		}
	}

	public class CustomIdGeneratorForOrderDto:ValueGenerator<string>
	{
		public override bool GeneratesTemporaryValues => false;

		public override string Next(EntityEntry entry)
		{
			return $"ORDER-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
		}
	}

}
