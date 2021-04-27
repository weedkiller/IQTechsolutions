using Microsoft.Extensions.DependencyInjection;
using Shopping.Core.Context.Services;

namespace Shopping.Core.Extensions
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
        public static IServiceCollection AddShopping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ShoppingCartContext>();
            return serviceCollection;
        }
    }
}


