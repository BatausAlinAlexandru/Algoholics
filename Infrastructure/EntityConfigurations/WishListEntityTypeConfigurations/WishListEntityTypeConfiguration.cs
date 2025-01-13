using Domain.Aggregates.WishListAggregate.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityConfigurations.WishListEntityTypeConfigurations
{
    class WishListEntityTypeConfiguration : IEntityTypeConfiguration<WishList>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<WishList> builder)
        {
            builder.ToTable("wishlist");
            builder.HasKey(e => e.Id);
        }
    }
}
