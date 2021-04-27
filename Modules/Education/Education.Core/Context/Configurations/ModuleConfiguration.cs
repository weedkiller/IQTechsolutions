using Education.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasOne(c => c.Course).WithMany(c => c.Modules).HasForeignKey(c => c.CourseId);

            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Sections).WithOne(c => c.Module).HasForeignKey(c => c.ModuleId);
            builder.HasMany(c => c.AssessmentElements).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
