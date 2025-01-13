using Domain.Aggregates.UserAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Infrastructure.EntityConfigurations.UserAccountEntityTypeConfigurations
{
    class UserAccountPaymentInfoEntityTypeConfiguration : IEntityTypeConfiguration<UserAccountPaymentInfo>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserAccountPaymentInfo> builder)
        {
            builder.ToTable("users_payment_info");
            builder.HasKey(p => p.Id);

        }
    }
}
