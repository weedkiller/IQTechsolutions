using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class RouteLocationConfiguration : IEntityTypeConfiguration<RouteLocation>
    {
        public void Configure(EntityTypeBuilder<RouteLocation> builder)
        {
            builder.HasOne(c => c.Route).WithMany(c => c.RouteLocations).HasForeignKey(c => c.RouteId);
            builder.HasOne(c => c.Address).WithOne(c => c.Entity);

            builder.HasMany(c => c.Tasks).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
