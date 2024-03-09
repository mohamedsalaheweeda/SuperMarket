using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class OrderConfigruation : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.List_Price).HasPrecision(20, 3).IsRequired();
            builder.Property(x => x.Time).HasColumnType("DateTime").IsRequired();
            builder.Property(x => x.Date).HasColumnType("DateTime").IsRequired();

            builder.ToTable("Orders", "Sales");

            builder.HasOne(x => x.Payment)
                .WithMany(x => x.Order)
                .HasForeignKey(x => x.PaymentId)
                .IsRequired(false);



        }
    }

}
