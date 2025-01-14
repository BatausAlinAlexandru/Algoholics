using Domain.Aggregates.OrderAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.OrderEntityTypeConfigurations
{
    public class OrderProductDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderProductDetail>
    {
        public void Configure(EntityTypeBuilder<OrderProductDetail> builder)
        {
            builder.ToTable("OrderProductDetails");
            builder.HasKey(opd => opd.Id);
            builder.Property(opd => opd.ProductId).IsRequired();
            builder.Property(opd => opd.Quantity).IsRequired();
        }
    }
}
