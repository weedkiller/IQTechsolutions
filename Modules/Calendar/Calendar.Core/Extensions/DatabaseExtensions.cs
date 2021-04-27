using Calendar.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyCalenderConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration())
                .ApplyConfiguration(new EventCategoryConfiguration())
                .ApplyConfiguration(new EventDayConfiguration())
                .ApplyConfiguration(new EventRegistrationConfiguration())
                .ApplyConfiguration(new RecurringTaskConfiguration())
                .ApplyConfiguration(new RouteConfiguration())
                .ApplyConfiguration(new RouteLocationConfiguration())
                .ApplyConfiguration(new RouteLocationTaskConfiguration());

            return modelBuilder;
        }
    }
}
