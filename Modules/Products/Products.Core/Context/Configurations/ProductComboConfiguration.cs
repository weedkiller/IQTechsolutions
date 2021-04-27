using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ProductComboConfiguration : IEntityTypeConfiguration<ComboCategory<Product>>
    {
        public void Configure(EntityTypeBuilder<ComboCategory<Product>> builder)
        {
            builder.HasKey(sc => new { sc.ComboItemId, sc.ComboRecipyCategoryId });

            builder.HasOne(c => c.ComboItem).WithMany(c => c.Combos).HasForeignKey(c => c.ComboItemId);
            builder.HasOne(c => c.ComboRecipyCategory).WithMany().HasForeignKey(c => c.ComboRecipyCategoryId);

            builder.HasMany(c => c.Exclusions).WithOne(c => c.ComboCategory).HasPrincipalKey(c => c.ComboRecipyCategoryId);
        }
    }
}
