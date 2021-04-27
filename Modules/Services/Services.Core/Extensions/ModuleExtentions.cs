using Microsoft.Extensions.DependencyInjection;
using Services.Core.Context.Services;

namespace Services.Core.Extensions
{
    public static class FeedbackModuleExtensions
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ServiceContext>();
            return serviceCollection;
        }
    }
}
