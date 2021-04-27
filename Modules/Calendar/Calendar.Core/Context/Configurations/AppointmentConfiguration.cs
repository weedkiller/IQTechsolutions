using Calendar.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Calendar.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId);
        }
    }
}
