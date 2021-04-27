using Education.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Education.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyCourseConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration())
                .ApplyConfiguration(new StudentCourseConfiguration())
                .ApplyConfiguration(new CourseDepartmentConfiguration())
                .ApplyConfiguration(new CourseCategoryConfiguration())
                .ApplyConfiguration(new CourseConfiguration())
                .ApplyConfiguration(new ModuleConfiguration())
                .ApplyConfiguration(new SectionConfiguration())
                .ApplyConfiguration(new StudentActivityConfiguration());
            return modelBuilder;
        }
    }
}
