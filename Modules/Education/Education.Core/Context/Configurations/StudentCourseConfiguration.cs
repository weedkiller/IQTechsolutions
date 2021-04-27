using Education.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for training courses
    /// </summary>
    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.HasOne(c => c.Student).WithMany(c => c.Courses).HasForeignKey(c => c.StudentId);
            builder.HasOne(c => c.Course).WithMany(c => c.Students).HasForeignKey(c => c.CourseId);
        }
    }
}
