using Domain.Aggregates.ProductAggregate.Entities;
using Domain.Aggregates.WishlistAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    public class WishlistEntityTypeConfiguration : IEntityTypeConfiguration<Wishlist>
    {
        public void Configure(EntityTypeBuilder<Wishlist> builder)
        {
            builder.ToTable("Wishlists");
            // Configure the primary key
            builder.HasKey(w => w.Id);

            // Configure the UserAccountId property
            builder.Property(w => w.UserAccountId)
                   .IsRequired();

            // Configure the relationship with Product
            builder.HasMany(w => w.Products)
            .WithMany()
            .UsingEntity<Dictionary<string, object>>(
                "WishlistProduct", // Join table name
                j => j.HasOne<Product>().WithMany().HasForeignKey("ProductId"), // Configure the Product side
                j => j.HasOne<Wishlist>().WithMany().HasForeignKey("WishlistId"), // Configure the Wishlist side
                j =>
                {
                    j.HasKey("WishlistId", "ProductId"); // Composite key
                });
        }
    }
}
