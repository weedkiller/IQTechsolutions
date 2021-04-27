using Education.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for student activities
    /// </summary>
    public class StudentActivityConfiguration : IEntityTypeConfiguration<StudentActivity>
    {
        public void Configure(EntityTypeBuilder<StudentActivity> builder)
        {
            builder.HasOne(c => c.Student).WithMany(c => c.Activities).HasForeignKey(c => c.StudentId);
        }
    }
}
