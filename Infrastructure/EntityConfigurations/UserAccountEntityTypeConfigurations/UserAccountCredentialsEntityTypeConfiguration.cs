using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations
{
    class UserAccountCredentialsEntityTypeConfiguration : IEntityTypeConfiguration<UserAccountCredentials>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccountCredentials> builder)
        {
            builder.ToTable("users_credentials");
            builder.HasKey(u => u.Id);

            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.Password)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
