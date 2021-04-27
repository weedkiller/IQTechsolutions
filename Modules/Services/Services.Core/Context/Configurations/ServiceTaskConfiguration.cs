using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Base.Entities;

namespace Services.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ServiceTaskConfiguration : IEntityTypeConfiguration<EntityTask<Service>>
    {
        public void Configure(EntityTypeBuilder<EntityTask<Service>> builder)
        {
            builder.HasKey(sc => new {sc.EntityId, sc.TaskId});

            builder.HasOne(c => c.Entity).WithMany(c => c.Tasks).HasForeignKey(c => c.EntityId);
            builder.HasOne(c => c.Task).WithMany().HasForeignKey(c => c.TaskId);
        }
    }
}
