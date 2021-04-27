using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Base.Entities;

namespace Services.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ServiceComboExclusionConfiguration : IEntityTypeConfiguration<ComboExclusions<Service>>
    {
        public void Configure(EntityTypeBuilder<ComboExclusions<Service>> builder)
        {
            builder.HasKey(sc => new { sc.ExclusionId, sc.ComboCategoryId });

            builder.HasOne(c => c.Exclusion).WithMany(c => c.Exclusions).HasForeignKey(c => c.ExclusionId);
        }
    }
}
