using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations
{
    class UserAccountInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserAccountInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccountInfo> builder)
        {
            builder.ToTable("users_info");
            builder.HasKey(i => i.Id);

            builder.HasOne(uai => uai.UserAccountPaymentCardInfo)
                .WithOne()
                .HasForeignKey<UserAccountPaymentInfo>(uapi => uapi.IdUserAccount)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
