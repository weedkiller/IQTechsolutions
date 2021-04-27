using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Base.Entities;

namespace Services.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class IncludedServiceConfiguration : IEntityTypeConfiguration<IncludedService<Service>>
    {
        public void Configure(EntityTypeBuilder<IncludedService<Service>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.ServiceId });

            builder.HasOne(c => c.Entity).WithMany(c => c.IncludedServices).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Service).WithMany().HasForeignKey(c => c.ServiceId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
