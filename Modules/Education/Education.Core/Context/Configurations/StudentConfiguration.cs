using Education.Base.Entities;
using Identity.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Education.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for training courses
    /// </summary>
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.OwnsOne(c => c.Names);

            builder.HasOne(c => c.UserInfo).WithOne().HasForeignKey<UserInfo>(c => c.StudentId);

            builder.HasMany(c => c.ContactNumbers).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Addresses).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.EmailAddresses).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Courses).WithOne(c => c.Student).HasForeignKey(c => c.StudentId);
        }
    }
}
