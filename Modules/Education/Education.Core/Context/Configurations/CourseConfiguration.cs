using Education.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for training courses
    /// </summary>
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Modules).WithOne(c => c.Course).HasForeignKey(c => c.CourseId);
            builder.HasMany(c => c.Students).WithOne(c => c.Course).HasForeignKey(c => c.CourseId);
            builder.HasMany(c => c.AssessmentElements).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
