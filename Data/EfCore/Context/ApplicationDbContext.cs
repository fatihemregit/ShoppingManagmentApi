using Data.EfCore.Config;
using Entity.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EfCore.Context
{
	//Add-Migration firstmig -Context Data.EfCore.Context.ApplicationDbContext -Project Data -OutputDir "Efcore//Migrations"
	public class ApplicationDbContext : DbContext
	{
        public DbSet<ProductDto> Products { get; set; }

        public DbSet<MarketDto> Markets { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductDtoConfig());
			modelBuilder.ApplyConfiguration(new MarketDtoConfig());

		}


	}
}
