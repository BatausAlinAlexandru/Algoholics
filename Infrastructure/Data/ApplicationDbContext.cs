using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Entities;
using Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserAccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountCredentialsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountSettingsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new WishlistEntityTypeConfiguration());
            
        }
    }
}