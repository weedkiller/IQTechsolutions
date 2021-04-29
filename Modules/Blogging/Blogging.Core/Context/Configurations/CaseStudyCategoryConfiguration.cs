using Blogging.Base.Entities;
using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class CaseStudyCategoryConfiguration : IEntityTypeConfiguration<EntityCategory<CaseStudy>>
    {
        public void Configure(EntityTypeBuilder<EntityCategory<CaseStudy>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.CategoryId });
            builder.HasOne(c => c.Entity).WithMany(c => c.Categories).HasForeignKey(c => c.EntityId);
            builder.HasOne(c => c.Category).WithMany(c => c.EntityCollection).HasForeignKey(c => c.CategoryId);
        }
    }
}
