using Grouping.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Grouping.Core.Extensions
{
    /// <summary>
    /// The module extension methods
    /// </summary>
    public static class ModuleExtensions
    {
        /// <summary>
        /// Adds the grouping services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddGrouping(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(DepartmentContext<>));
            serviceCollection.AddScoped(typeof(CategoryContext<>));
            return serviceCollection;
        }
    }
}
