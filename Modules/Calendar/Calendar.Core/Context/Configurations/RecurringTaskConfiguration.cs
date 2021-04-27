using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class RecurringTaskConfiguration : IEntityTypeConfiguration<RecurringTask>
    {
        public void Configure(EntityTypeBuilder<RecurringTask> builder)
        {
            builder.HasOne(c => c.Address).WithOne(c => c.Entity);

            builder.HasMany(c => c.Tasks).WithOne(c => c.ParentTask).HasForeignKey(c => c.ParentTaskId);
            builder.HasMany(c => c.LocationTasks).WithOne(c => c.Task).HasForeignKey(c => c.TaskId);
            builder.HasMany(c => c.FormElements).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
