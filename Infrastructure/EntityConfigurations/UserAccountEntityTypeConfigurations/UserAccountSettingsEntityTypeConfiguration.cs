using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations
{
    class UserAccountSettingsEntityTypeConfiguration : IEntityTypeConfiguration<UserAccountSettings>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccountSettings> builder)
        {
            builder.ToTable("users_settings");
            builder.HasKey(s => s.Id);
        }
    }
}
