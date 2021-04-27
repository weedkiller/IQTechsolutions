using Messaging.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Core.Extensions
{
    public static class ChatModuleExtensions
    {
        public static IServiceCollection AddMessaging(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ChatContext>()
                .AddTransient<NotificationContext>()
                .AddTransient<TimeLineContext>();
            return serviceCollection;
        }
    }
}
