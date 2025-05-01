using Data.PostgreSql.Config;
using Entity.Auth;
using Entity.Dto;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PostgreSql.Context
{
	public class ApplicationDbContextPostgre: IdentityDbContext<AppUser, AppRole, Guid>
	{
		public DbSet<ProductDto> Products { get; set; }

		public DbSet<MarketDto> Markets { get; set; }

		public DbSet<OrderDto> Orders { get; set; }

		public ApplicationDbContextPostgre(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductDtoConfig());
			modelBuilder.ApplyConfiguration(new MarketDtoConfig());
			modelBuilder.ApplyConfiguration(new OrderDtoConfig());
			base.OnModelCreating(modelBuilder);

		}
	}
}
