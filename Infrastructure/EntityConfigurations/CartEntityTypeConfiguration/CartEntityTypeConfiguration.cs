using Domain.Aggregates.CartAggregate.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfigurations.CartEntityTypeConfigurations
{
    class CartEntityTypeConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Cart");
            builder.HasKey(c => c.Id);

            // If you want to store CartItem as an owned type or separate table, 
            // you can do so. For example, as owned collection:
            builder.OwnsMany(c => c.Items, i =>
            {
                i.ToTable("CartItem");
                i.WithOwner().HasForeignKey("CartId");
                i.HasKey("CartId", "ProductId"); // composite key, for example
            });
        }
    }
}
