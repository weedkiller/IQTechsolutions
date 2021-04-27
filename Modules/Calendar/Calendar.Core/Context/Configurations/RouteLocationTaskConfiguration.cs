using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class RouteLocationTaskConfiguration : IEntityTypeConfiguration<EntityTask<RouteLocation>>
    {
        public void Configure(EntityTypeBuilder<EntityTask<RouteLocation>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.TaskId });

            builder.HasOne(c => c.Entity).WithMany(c => c.Tasks).HasForeignKey(c => c.EntityId);
            builder.HasOne(c => c.Task).WithMany(c => c.LocationTasks).HasForeignKey(c => c.TaskId);
        }
    }
}
