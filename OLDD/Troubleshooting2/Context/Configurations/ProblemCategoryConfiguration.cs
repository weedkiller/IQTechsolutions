using Grouping.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Troubleshooting.Entities;

namespace Troubleshooting.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ProblemCategoryConfiguration : IEntityTypeConfiguration<EntityCategory<Problem>>
    {
        public void Configure(EntityTypeBuilder<EntityCategory<Problem>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.CategoryId });

            builder.HasOne(c => c.Entity).WithMany(c => c.Categories).HasForeignKey(c => c.EntityId);
            builder.HasOne(c => c.Category).WithMany(c => c.EntityCollection).HasForeignKey(c => c.CategoryId);
        }
    }
}
