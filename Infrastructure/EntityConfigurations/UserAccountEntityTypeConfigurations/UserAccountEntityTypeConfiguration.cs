using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations
{
    class UserAccountEntityTypeConfiguration : IEntityTypeConfiguration<UserAccount>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccount> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.UserAccountCredentials)
                .WithOne()
                .HasForeignKey<UserAccountCredentials>(c => c.Id);

            builder.HasOne(u => u.UserAccountSettings)
                .WithOne()
                .HasForeignKey<UserAccountSettings>(s => s.Id);
            builder.HasOne(u => u.UserAccountInfo)
                .WithOne()
                .HasForeignKey<UserAccountInfo>(s => s.Id);
        }
    }
}
