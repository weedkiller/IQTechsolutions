using Messaging.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Messaging.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyMessagingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatConfiguration())
                .ApplyConfiguration(new ChatUserConfiguration())
                .ApplyConfiguration(new MessageConfiguration())
                .ApplyConfiguration(new NotificationConfiguration())
                .ApplyConfiguration(new TimelineItemConfiguration());
            return modelBuilder;
        }
    }
}
