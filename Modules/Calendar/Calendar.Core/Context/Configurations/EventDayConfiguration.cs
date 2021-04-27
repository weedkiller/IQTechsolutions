using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class EventDayConfiguration : IEntityTypeConfiguration<EventDay>
    {
        public void Configure(EntityTypeBuilder<EventDay> builder)
        {
            builder.HasOne(c => c.Event).WithMany(c => c.EventDays).HasForeignKey(c => c.EventId);
        }
    }
}
