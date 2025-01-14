using Domain.Aggregates.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.ProductEntityTypeConfigurations
{
    public class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Configurare tabel
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);

            // Configurare proprietăți de bază
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Description)
                .HasMaxLength(1000);

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.Property(p => p.Discount)
                .IsRequired();

            builder.Property(p => p.PhotoUrl)
                .HasMaxLength(500);

            // Configurare pentru ProductSpecifications (Owned Collection)
            builder.OwnsMany(p => p.Filters, ps =>
            {
                ps.Property(s => s.IdFilterGroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("IdFilterGroup");

                ps.Property(s => s.IdFilterValue)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("IdFilterValue");

                ps.WithOwner(); // Specifică că aparțin lui Product
            });

        }
    }
}
