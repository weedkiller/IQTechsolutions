using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Context.Configurations
{
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class ProblemConfiguration : IEntityTypeConfiguration<Problem>
    {
        public void Configure(EntityTypeBuilder<Problem> builder)
        {
            builder.HasMany(c => c.Causes).WithOne(c => c.Problem).HasForeignKey(c => c.ProblemId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
