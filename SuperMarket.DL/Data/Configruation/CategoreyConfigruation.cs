using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMarket.DL;

namespace SuperMarket.DL
{
    public class CategoreyConfigruation : IEntityTypeConfiguration<Categorey>
    {
        public void Configure(EntityTypeBuilder<Categorey> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Image).HasMaxLength(150).IsRequired(false);


            builder.ToTable("Categories", "Production");

           
            builder.HasOne(x=>x.Brand)
                .WithMany(x=>x.Categorey)
                .HasForeignKey(x=>x.BrandId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
