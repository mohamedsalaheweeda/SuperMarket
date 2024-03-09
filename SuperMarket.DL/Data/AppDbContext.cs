
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using SuperMarket.DL;
using System.Security.Principal;

namespace SuperMarket.Model.Data
{
    public class AppDbContext : IdentityDbContext<User , IdentityRole<int> , int>
    {
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Categorey> Categories { get; set; }
        public DbSet<ProductWithOrder> ProductWithOrders { get; set; }
        public AppDbContext()
        {
            
        }

        public AppDbContext(DbContextOptions options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source = mohamedsalah ; Initial Catalog = MiniSuperMarket ; Integrated Security = true ; Encrypt = false");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
