﻿using eShop.Database.Configs;
using eShop.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace eShop.Database
{
	public class AppDbContext : DbContext
	{
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<Product> Products { get; set; }	

		public AppDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductCaregoryConfig());
			modelBuilder.ApplyConfiguration(new ProductConfig());
		}
	}
}