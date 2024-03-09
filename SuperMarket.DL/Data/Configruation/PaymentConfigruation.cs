using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class PaymentConfigruation : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Type_Amount).HasPrecision(20, 3).IsRequired();
            builder.Property(x => x.Amount).HasPrecision(20, 3).IsRequired();


            builder.ToTable("Payments", "Sales");




        }
    }

}
