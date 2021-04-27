using System.Reflection;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Troubleshooting.Core.Context.Services;
using Troubleshooting.Core.ViewComponents;

namespace Troubleshooting.Core.Extensions
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
        public static IServiceCollection AddFaqs(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<FaqContext>();

            var assembly = typeof(FaqCategoryList).GetTypeInfo().Assembly;
            var embeddedFileProvider = new EmbeddedFileProvider(
                assembly
            );

            serviceCollection.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });

            return serviceCollection;
        }

        public static IServiceCollection AddTroubleshooting(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProblemsContext>();
            return serviceCollection;
        }
    }
}
