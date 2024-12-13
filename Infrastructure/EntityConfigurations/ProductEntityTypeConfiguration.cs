using Domain.Aggregates.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Set table name
            builder.ToTable("Products");

            // Set primary key
            builder.HasKey(p => p.Id);

            // Configure properties
            builder.Property(p => p.Id)
                   .IsRequired()
                   .ValueGeneratedOnAdd(); // Auto-generated ID

            builder.OwnsOne(p => p.ProductDetail, pd =>
            {
                pd.Property(d => d.Name)
                  .IsRequired()
                  .HasMaxLength(100);

                pd.Property(d => d.Price)
                  .IsRequired()
                  .HasColumnType("decimal(18,2)");

                pd.Property(d => d.Description)
                  .HasMaxLength(500);

                pd.Property(d => d.Stoc)
                  .IsRequired();

                pd.Property(d => d.Discount)
                  .IsRequired();

                pd.Property(d => d.pathFoto)
                  .HasMaxLength(250);
            });
        }
    }
}
