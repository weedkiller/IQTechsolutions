using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Base.Entities;

namespace Services.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service entity
    /// </summary>
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(200);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);

            builder.HasMany(c => c.Tasks).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);

            builder.HasMany(c => c.Combos).WithOne(c => c.ComboItem).HasForeignKey(c => c.ComboItemId);
            builder.HasMany(c => c.Exclusions).WithOne(c => c.Exclusion).HasForeignKey(c => c.ExclusionId);

            builder.HasMany(c => c.IncludedServices).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.OptionalServices).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(c => c.Reviews).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
