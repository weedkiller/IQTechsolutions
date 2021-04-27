using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ProductComboExclusionConfiguration : IEntityTypeConfiguration<ComboExclusions<Product>>
    {
        public void Configure(EntityTypeBuilder<ComboExclusions<Product>> builder)
        {
            builder.HasKey(sc => new { sc.ExclusionId, sc.ComboCategoryId });

            builder.HasOne(c => c.Exclusion).WithMany(c => c.Exclusions).HasForeignKey(c => c.ExclusionId);
        }
    }
}
