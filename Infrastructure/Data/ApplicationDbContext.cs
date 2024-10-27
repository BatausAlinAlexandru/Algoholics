using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Infrastructure.Data
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserAccount> Users { get; set; }

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
        }
    }
}