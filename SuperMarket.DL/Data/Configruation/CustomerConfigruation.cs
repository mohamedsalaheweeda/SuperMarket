using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class CustomerConfigruation : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.First_Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Mid_Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Last_Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired(false);
            builder.Property(x => x.Country).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.City).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Street).HasMaxLength(50).IsRequired(false);
            builder.Property(x => x.Phone).HasMaxLength(11).IsRequired();
            builder.ToTable("Customers", "Sales");
            builder.HasMany(x => x.product)
               .WithMany(x => x.Customer);
            builder.HasMany(x => x.Order)
             .WithOne(x => x.Customer)
             .HasForeignKey(x => x.CustomerId)
             .IsRequired(false);
            builder.HasMany(x => x.Payment)
             .WithOne(x => x.Customer)
             .HasForeignKey(x => x.CustomerId)
             .IsRequired(false);
            builder.HasMany(x => x.Review)
            .WithOne(x => x.Customer)
            .HasForeignKey(x => x.CustomerId)
            .IsRequired(false);
        }
    }

}
