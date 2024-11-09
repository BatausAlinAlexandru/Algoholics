using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations
{
    class UserAccountInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserAccountInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccountInfo> builder)
        {
            builder.ToTable("users_info");
            builder.HasKey(i => i.Id);
        }
    }
}
