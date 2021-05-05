using Microsoft.Extensions.DependencyInjection;
using Suppliers.Core.Context.Services;

namespace Suppliers.Core.Extensions
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
        public static IServiceCollection AddSuppliers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<SupplierContext>();
            return serviceCollection;
        }
    }
}
