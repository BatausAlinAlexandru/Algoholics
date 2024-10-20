using Domain.Aggregates.UserAggregate.Entities;
using Domain.Aggregates.UserAggregate.Value_Objects;
using Microsoft.EntityFrameworkCore;

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

            modelBuilder.Entity<UserAccount>().HasKey(u => u.Id);
            modelBuilder.Entity<UserAccountCredentials>().HasKey(u => u.Email);

        }
    }
}