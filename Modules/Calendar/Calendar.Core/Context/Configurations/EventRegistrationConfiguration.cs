using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class EventRegistrationConfiguration : IEntityTypeConfiguration<EventRegistration>
    {
        public void Configure(EntityTypeBuilder<EventRegistration> builder)
        {
            builder.HasOne(c => c.Event).WithMany(c => c.Registrations).HasForeignKey(c => c.EventId);
        }
    }
}
