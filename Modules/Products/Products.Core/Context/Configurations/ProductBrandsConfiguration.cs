using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class ProductBrandsConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder.HasKey(sc => new { sc.ProductId, sc.BrandId });

            builder.HasOne(c => c.Brand).WithMany(c => c.ProductBrands).HasForeignKey(c => c.BrandId);
            builder.HasOne(c => c.Product).WithMany(c => c.Brands).HasForeignKey(c => c.ProductId);
        }
    }
}
