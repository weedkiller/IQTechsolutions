using Blogging.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Blogging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class CaseStucyConfiguration : IEntityTypeConfiguration<CaseStudy>
    {
        public void Configure(EntityTypeBuilder<CaseStudy> builder)
        {
            builder.Property(c => c.Title).HasMaxLength(200).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(5000);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}