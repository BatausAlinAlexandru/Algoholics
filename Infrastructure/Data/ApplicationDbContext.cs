using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Infrastructure.EntityConfigurations;
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

            modelBuilder.ApplyConfiguration(new UserAccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountCredentialsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountSettingsEntityTypeConfiguration());


            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<ProductDetail>().ToTable("product_details");

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<ProductDetail>().HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.ProductDetail)
                .WithOne()
                .HasForeignKey<ProductDetail>(p => p.Id);

        }
    }
}