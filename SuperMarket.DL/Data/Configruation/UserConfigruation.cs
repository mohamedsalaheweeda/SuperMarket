using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class UserConfigruation : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(11).IsRequired();
            builder.ToTable("Users", "Production");

            builder.HasMany(x => x.Brand)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.Customer)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.Product)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Payment)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.ProductWithOrder)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Order)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.Stock)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.Review)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId)
               .IsRequired();
            builder.HasMany(x => x.Categories)
                 .WithOne(x => x.User)
                 .HasForeignKey(x => x.UserId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Restrict);

        }
    }

}
