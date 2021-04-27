using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messaging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class TimelineItemConfiguration : IEntityTypeConfiguration<TimelineItem>
    {
        public void Configure(EntityTypeBuilder<TimelineItem> builder)
        {
            builder.HasOne(c => c.Owner).WithMany().HasForeignKey(c => c.OwnerId);
        }
    }
}
