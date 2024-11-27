using Domain.Aggregates.CategoryAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.CategoryEntityTypeConfigurations
{
    internal class FilterValueEntityTypeConfiguration : IEntityTypeConfiguration<FilterValue>
    {
        public void Configure(EntityTypeBuilder<FilterValue> builder)
        {
            builder.ToTable("filter_value");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Name).IsRequired().HasMaxLength(50);

            // Relație cu Subcategory - pe baza Foreign Key
            builder.HasOne<FilterGroup>()
                   .WithMany()
                   .HasForeignKey(sc => sc.IdFilterGroup)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
