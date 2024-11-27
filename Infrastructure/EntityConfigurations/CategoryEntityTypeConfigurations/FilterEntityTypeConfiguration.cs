using Domain.Aggregates.CategoryAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.CategoryEntityTypeConfigurations
{
    internal class FilterEntityTypeConfiguration : IEntityTypeConfiguration<FilterGroup>
    {
        public void Configure(EntityTypeBuilder<FilterGroup> builder)
        {
            builder.ToTable("filter_group");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(50);

            // Relație cu Subcategory - pe baza Foreign Key
            builder.HasOne<Subcategory>()
                   .WithMany()
                   .HasForeignKey(sc => sc.IdSubcategory)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
