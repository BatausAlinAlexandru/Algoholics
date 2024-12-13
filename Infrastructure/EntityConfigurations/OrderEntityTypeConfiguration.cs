using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Aggregates.OrderAggregate.Entities;

public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        // Primary key
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id).ValueGeneratedOnAdd();

        // Properties
        builder.Property(o => o.OrderDate);
        builder.Property(o => o.OrderTotalPrice);
        builder.Property(o => o.OrderStatus)
               .HasConversion<string>(); // Enum to string conversion

        // Foreign key for UserAccountId
        builder.Property(o => o.UserAccountId);

        // Configure the relationship explicitly if needed
        //builder.HasIndex(o => o.UserAccountId) // Optional, for faster lookups
        //       .HasDatabaseName("IX_Order_UserAccountId");

        // One-to-many relationship with OrderDetails
        builder.OwnsMany(o => o.OrderDetails, od =>
        {
            od.WithOwner().HasForeignKey("OrderId"); 
            od.HasKey(d => d.Id); 
            od.Property(d => d.ProductName);
            od.Property(d => d.Quantity);
            od.Property(d => d.TotalPrice);
            od.Property(d => d.PaymentMethod);
        });
    }
}
