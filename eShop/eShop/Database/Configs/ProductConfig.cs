using eShop.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace eShop.Database.Configs
{
	public class ProductConfig : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.Property(x => x.Name).HasMaxLength(200);
			builder.Property(x => x.Decription).HasColumnType("ntext");
			builder.Property(x => x.CoverImg).HasMaxLength(500);

			//Khoa ngoai
			builder.HasOne(x => x.ProductCategory)
				.WithMany()
				.IsRequired(false)
				.HasForeignKey(x => x.CategoryId);
		}
	}

}
