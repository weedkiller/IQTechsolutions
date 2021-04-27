using Microsoft.Extensions.DependencyInjection;
using Projects.Core.Context.Services;

namespace Projects.Core.Extensions
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
        public static IServiceCollection AddProjects(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProjectsContext>();
            return serviceCollection;
        }
    }
}
