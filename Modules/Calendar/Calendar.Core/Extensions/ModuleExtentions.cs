using Calendar.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Calendar.Core.Extensions
{
    public static class CalenderModuleExtensions
    {
        public static IServiceCollection AddCalender(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient< CalenderContext>();
            serviceCollection.AddTransient<TaskContext>();
            serviceCollection.AddTransient<FormElementContext>();
            serviceCollection.AddTransient<EventContext>();
            return serviceCollection;
        }
    }
}
