using Education.Core.Context.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Education.Core.Extensions
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
        public static IServiceCollection AddCourses(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CourseContext>();
            serviceCollection.AddTransient<ModuleContext>();
            serviceCollection.AddTransient<SectionContext>();
            serviceCollection.AddTransient<StudentContext>();
            return serviceCollection;
        }
    }
}
