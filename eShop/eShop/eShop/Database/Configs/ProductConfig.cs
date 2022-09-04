using eShop.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eShop.Database.Configs
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> buider)
        {
            buider.Property(x => x.Name).HasMaxLength(200);
            buider.Property(x => x.Description).HasColumnType("nText");
            buider.Property(x => x.CoverImg).HasMaxLength(500);
            //khoas ngoai

            buider.HasOne(x => x.ProductCategory)
                .WithMany()
                .IsRequired(false)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
