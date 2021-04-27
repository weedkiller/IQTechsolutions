using Iqt.Troubleshooting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iqt.Troubleshooting.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class CauseConfiguration : IEntityTypeConfiguration<Cause>
    {
        public void Configure(EntityTypeBuilder<Cause> builder)
        {
            builder.HasOne(c => c.Problem).WithMany(c => c.Causes).HasForeignKey(c => c.ProblemId);

            builder.HasMany(c => c.CorrectiveActions).WithOne(c => c.Cause).HasForeignKey(c => c.CauseId);
        }
    }
}
