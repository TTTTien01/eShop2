using eShop.Database.Configs;
using eShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using eShop.Areas.Admin.ViewModels.Category;
using eShop.Areas.Admin.ViewModels.Product;

namespace eShop.Database
{
    public class AddDbContext : DbContext
    {
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        public AddDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());

        }
        public DbSet<eShop.Areas.Admin.ViewModels.Category.AddOrUpdateCategoryVM>? AddOrUpdateCategoryVM { get; set; }
        public DbSet<eShop.Areas.Admin.ViewModels.Category.ListItemCategoryVM> ListItemCategoryVM { get; set; }

		public DbSet<eShop.Areas.Admin.ViewModels.Product.AddOrUpdateProductVM>? AddOrUpdateProductVM { get; set; }
		public DbSet<eShop.Areas.Admin.ViewModels.Product.ListItemProductVM> ListItemProductVM { get; set; }
	}
}
