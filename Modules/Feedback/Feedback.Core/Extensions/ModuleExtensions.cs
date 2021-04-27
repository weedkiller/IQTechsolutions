using Feedback.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;
using Olympia.Web.Email.Extensions;

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
            serviceCollection.AddCustomEmailServices();
            return serviceCollection;
        }
    }
}
