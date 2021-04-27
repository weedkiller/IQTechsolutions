using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(c => c.Heading).HasMaxLength(1500);
            builder.Property(c => c.Description).HasMaxLength(5000);

            builder.HasOne(c => c.Location).WithMany().HasForeignKey(c => c.LocationId);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.EventVideos).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Contacts).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Registrations).WithOne(c => c.Event).HasForeignKey(c => c.EventId);
            builder.HasMany(c => c.EventDays).WithOne(c => c.Event).HasForeignKey(c => c.EventId);
        }
    }
}