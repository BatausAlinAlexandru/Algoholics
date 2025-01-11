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
                   .WithOne() // Assuming no navigation property in Product back to Wishlist
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
