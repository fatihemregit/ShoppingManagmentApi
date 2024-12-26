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
	public class ProductDtoConfig : IEntityTypeConfiguration<ProductDto>
	{
		public void Configure(EntityTypeBuilder<ProductDto> builder)
		{
			//adding to ready data(builder.hasdata)
			builder.HasData(
				new ProductDto { Id= "PROD-B4019871", BarcodeNumber = "8690504111030", ProductName = "Ülker muzlu rondo", Price = 12.90m ,MarketId  = 1},
				new ProductDto { Id = "PROD-652D25BE", BarcodeNumber = "8690504087038", ProductName = "Ülker Can pare", Price = 9.90m, MarketId = 1 },
				new ProductDto { Id = "PROD-E8A02162", BarcodeNumber = "8690504008002", ProductName = "Ülker çoko prens", Price = 10.90m, MarketId = 1 }
				);
			//indicateing to id prop is primary key
			builder.HasKey(p => p.Id);
			//setting to custom id system
			builder.Property(p => p.Id)
				.HasValueGenerator<CustomIdGeneratorForProductDto>()
				.IsRequired();
		}
	}

	public class CustomIdGeneratorForProductDto : ValueGenerator<string>
	{
		public override bool GeneratesTemporaryValues => false;

		public override string Next(EntityEntry entry)
		{
			return $"PROD-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
		}
	}


}
