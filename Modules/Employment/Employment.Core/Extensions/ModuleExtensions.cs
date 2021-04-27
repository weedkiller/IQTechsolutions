using Employment.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Employment.Core.Extensions
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
        public static IServiceCollection AddEmployment(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<EmployeeContext>();
            return serviceCollection;
        }
    }
}
