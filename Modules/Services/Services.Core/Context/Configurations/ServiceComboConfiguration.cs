using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Services.Base.Entities;

namespace Services.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ServiceComboConfiguration : IEntityTypeConfiguration<ComboCategory<Service>>
    {
        public void Configure(EntityTypeBuilder<ComboCategory<Service>> builder)
        {
            builder.HasKey(sc => new { sc.ComboItemId, sc.ComboRecipyCategoryId });

            builder.HasOne(c => c.ComboItem).WithMany(c => c.Combos).HasForeignKey(c => c.ComboItemId);
            builder.HasOne(c => c.ComboRecipyCategory).WithMany().HasForeignKey(c => c.ComboRecipyCategoryId);

            builder.HasMany(c => c.Exclusions).WithOne(c => c.ComboCategory).HasPrincipalKey(c => c.ComboRecipyCategoryId);
        }
    }
}
