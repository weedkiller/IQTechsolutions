using Employment.Base.Entities;
using Identity.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employment.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(c => c.Names);
            builder.OwnsOne(c => c.SocialMedia);
            builder.HasMany(c => c.Skills).WithOne(c => c.Employee).HasForeignKey(c => c.EmployeeId);

            builder.HasOne(c => c.UserInfo).WithOne().HasForeignKey<UserInfo>(c => c.EmployeeId);
        }
    }
}