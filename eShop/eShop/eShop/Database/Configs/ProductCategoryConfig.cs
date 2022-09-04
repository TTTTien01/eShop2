using eShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Database.Configs
{
        public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>

        {
            public void Configure(EntityTypeBuilder<ProductCategory> buider)
            {
                buider.Property(x => x.Name).HasMaxLength(200);
            }
        }

    
}
