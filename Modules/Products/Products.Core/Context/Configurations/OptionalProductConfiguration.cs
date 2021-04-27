using Iqt.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Iqt.Inventory.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class OptionalProductConfiguration : IEntityTypeConfiguration<OptionalProduct<Product>>
    {
        public void Configure(EntityTypeBuilder<OptionalProduct<Product>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.ProductId });

            builder.HasOne(c => c.Entity).WithMany(c => c.OptionalProducts).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
