using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserAccount>().ToTable("users");
            modelBuilder.Entity<UserAccountCredentials>().ToTable("users_credentials");
            modelBuilder.Entity<UserAccountSettings>().ToTable("users_settings");

            modelBuilder.Entity<UserAccount>().HasKey(u => u.Id);
            modelBuilder.Entity<UserAccountCredentials>().HasKey(u => u.Id);
            modelBuilder.Entity<UserAccountCredentials>().HasIndex(c => c.Email).IsUnique();
            modelBuilder.Entity<UserAccountSettings>().HasKey(s => s.Id);

            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.UserAccountCredentials)
                .WithOne()
                .HasForeignKey<UserAccountCredentials>(c => c.Id);

            modelBuilder.Entity<UserAccount>()
                .HasOne(u => u.UserAccountSettings)
                .WithOne()
                .HasForeignKey<UserAccountSettings>(s => s.Id);

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<ProductDetail>().ToTable("product_details");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductDetail>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetail)
                .WithOne()
                .HasForeignKey<ProductDetail>(p => p.Id);

         /*   modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<OrderDetail>().ToTable("order_details");

            modelBuilder.Entity<Order>().HasKey(o => o.Id);
            modelBuilder.Entity<OrderDetail>().HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderDetails)
                .WithOne()
                .HasForeignKey<OrderDetail>(o => o.Id);*/

        }
    }
}