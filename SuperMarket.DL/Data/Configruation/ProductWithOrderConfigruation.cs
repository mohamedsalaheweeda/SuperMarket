using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class ProductWithOrderConfigruation : IEntityTypeConfiguration<ProductWithOrder>
    {
        public void Configure(EntityTypeBuilder<ProductWithOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Discount_AllTotal).HasPrecision(20, 3).IsRequired();
            builder.Property(x => x.Quantity).HasPrecision(20, 3).IsRequired();
            builder.ToTable("ProductWithOrders", "Production");



        }
    }

}
