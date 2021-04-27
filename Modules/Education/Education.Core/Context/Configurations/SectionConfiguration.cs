using Education.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasOne(c => c.Module).WithMany(c => c.Sections).HasForeignKey(c => c.ModuleId);
            builder.HasOne(c => c.ParentSection).WithMany(c => c.Sections).HasForeignKey(c => c.ParentSectionId);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Sections).WithOne(c => c.ParentSection).HasForeignKey(c => c.ParentSectionId);
        }
    }
}
