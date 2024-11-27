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

            // Configurare pentru ProductCategory (Owned Type)
            builder.OwnsOne(p => p.ProductCategory, pc =>
            {
                pc.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("CategoryName"); // Coloana în tabel

                pc.Property(c => c.Description)
                    .HasMaxLength(500)
                    .HasColumnName("CategoryDescription"); // Coloana în tabel
            });

            // Configurare pentru ProductSpecifications (Owned Collection)
            builder.OwnsMany(p => p.productSpecifications, ps =>
            {
                ps.Property(s => s.Key)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("SpecificationKey");

                ps.Property(s => s.Value)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("SpecificationValue");

                ps.WithOwner(); // Specifică că aparțin lui Product
            });
        }
    }
}
