using Iqt.Troubleshooting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Troubleshooting.Entities;

namespace Iqt.Troubleshooting.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class CorrectiveActionConfiguration : IEntityTypeConfiguration<CorrectiveAction>
    {
        public void Configure(EntityTypeBuilder<CorrectiveAction> builder)
        {
            builder.HasOne(c => c.Cause).WithMany(c => c.CorrectiveActions).HasForeignKey(c => c.CauseId);
        }
    }
}
