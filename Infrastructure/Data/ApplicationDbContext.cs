using Domain.Aggregates.CategoryAggregate.Entities;
using Domain.Aggregates.OrderAggregate.Entities;
using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.UserAggregate.Entities;
using Infrastructure.EntityConfigurations.CategoryEntityTypeConfigurations;
using Infrastructure.EntityConfigurations.ProductEntityTypeConfigurations;
using Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FilterGroup> FilterGroups { get; set; }
        public DbSet<FilterValue> FilterValues { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfiguration(new UserAccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountCredentialsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountInfoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAccountSettingsEntityTypeConfiguration());


            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());

            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SubcategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilterEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FilterValueEntityTypeConfiguration());


        }
    }
}