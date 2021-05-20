using Feedback.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Feedback.Core.Extensions
{
    /// <summary>
    /// The module extension methods
    /// </summary>
    public static class ModuleExtensions
    {
        public static IServiceCollection AddSupportTicketSystem(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(TicketContext<>));
            return serviceCollection;
        }
    }
}
