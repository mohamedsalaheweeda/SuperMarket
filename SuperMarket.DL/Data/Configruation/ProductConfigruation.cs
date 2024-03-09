using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class ProductConfigruation : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Model_Year).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasPrecision(20, 3).IsRequired();
            builder.Property(x => x.Discount).HasPrecision(20, 3).IsRequired();
            builder.Property(x => x.Quantity).HasPrecision(20, 3).IsRequired();
            builder.ToTable("Products", "Production");


            builder.HasMany(x => x.Stock)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductId)
               .IsRequired(false);

            builder.HasMany(x => x.Order)
             .WithMany(x => x.Product)
             .UsingEntity<ProductWithOrder>();

            builder.HasOne(x => x.Brand)
              .WithMany(x => x.product)
              .HasForeignKey(x => x.BrandId)
              .IsRequired(false);

            builder.HasOne(x => x.Categorey)
              .WithMany(x => x.product)
              .HasForeignKey(x => x.Categoreyid)
              .IsRequired(false);
        }
    }

}
