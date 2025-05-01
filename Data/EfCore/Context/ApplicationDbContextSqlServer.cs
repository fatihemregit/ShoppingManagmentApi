using Data.EfCore.Config;
using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Entity.Auth;

namespace Data.EfCore.Context
{
	//Add-Migration firstmig -Context Data.EfCore.Context.ApplicationDbContextSqlServer -Project Data -OutputDir "Efcore//Migrations"
	public class ApplicationDbContextSqlServer : IdentityDbContext<AppUser,AppRole,Guid>
	{
        public DbSet<ProductDto> Products { get; set; }

        public DbSet<MarketDto> Markets { get; set; }

		public DbSet<OrderDto> Orders { get; set; }


		public ApplicationDbContextSqlServer(DbContextOptions options) : base(options)
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
