using Domain.Aggregates.CategoryAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.CategoryEntityTypeConfigurations
{
    internal class SubcategoryEntityTypeConfiguration : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            // Nume tabelă
            builder.ToTable("subcategories");

            // Cheie primară
            builder.HasKey(sc => sc.Id);

            // Proprietăți
            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(50);

            // Relație cu Category - pe baza Foreign Key
            builder.HasOne<Category>()
                   .WithMany()
                   .HasForeignKey(sc => sc.IdCategory)
                   .OnDelete(DeleteBehavior.Cascade);

            // Relație cu FilterGroup - pe baza Foreign Key
            builder.HasMany(sc => sc.FiltersGroups)
                   .WithOne()
                   .HasForeignKey(f => f.IdSubcategory)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
