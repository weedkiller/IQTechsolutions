using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(200);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Brands).WithOne(c => c.Product).HasForeignKey(c => c.ProductId);
            
            builder.HasMany(c => c.Combos).WithOne(c => c.ComboItem).HasForeignKey(c => c.ComboItemId);
            builder.HasMany(c => c.Exclusions).WithOne(c => c.Exclusion).HasForeignKey(c => c.ExclusionId);
            builder.HasMany(c => c.Reviews).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);

            builder.HasMany(c => c.IncludedProducts).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.OptionalProducts).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId).OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(c => c.PackageItems).WithOne(c => c.Packaging).HasForeignKey(c => c.PackagingId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
