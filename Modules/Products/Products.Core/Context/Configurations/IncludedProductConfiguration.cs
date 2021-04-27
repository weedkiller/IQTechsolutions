using Iqt.Inventory.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class IncludedProductConfiguration : IEntityTypeConfiguration<IncludedProduct<Product>>
    {
        public void Configure(EntityTypeBuilder<IncludedProduct<Product>> builder)
        {
            builder.HasKey(sc => new { sc.EntityId, sc.ProductId });

            builder.HasOne(c => c.Entity).WithMany(c => c.IncludedProducts).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(c => c.Product).WithMany().HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
