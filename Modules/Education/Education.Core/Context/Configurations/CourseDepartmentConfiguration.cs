using Education.Base.Entities;
using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class CourseDepartmentConfiguration : IEntityTypeConfiguration<Department<Course>>
    {
        public void Configure(EntityTypeBuilder<Department<Course>> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Categories).WithOne(c => c.Department).HasForeignKey(c => c.DepartmentId);
        }
    }
}
