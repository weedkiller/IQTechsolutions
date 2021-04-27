using Customers.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Core.Extensions
{
    /// <summary>
    /// The module extension methods
    /// </summary>
    public static class ModuleExtensions
    {
        /// <summary>
        /// Adds the training courses services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddCustomers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CustomerContext>();
            return serviceCollection;
        }

        /// <summary>
        /// Adds the training courses services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddAffiliates(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<AffiliateContext>();
            return serviceCollection;
        }
    }
}
