using System.Reflection;
using Blogging.Core.Context.Services;
using Blogging.Core.ViewComponents;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Blogging.Core.Extensions
{
    /// <summary>
    /// The module extension methods
    /// </summary>
    public static class ModuleExtensions
    {
        /// <summary>
        /// Adds the blog entries services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddBlogging(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<BlogContext>();

            var assembly = typeof(BlogCategoryList).GetTypeInfo().Assembly;
            var embeddedFileProvider = new EmbeddedFileProvider(
                assembly
            );

            serviceCollection.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });
            return serviceCollection;
        }

        /// <summary>
        /// Adds the case studies services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddCaseStudies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<CaseStudyContext>();

            var assembly = typeof(CaseStudyCategoryList).GetTypeInfo().Assembly;
            var embeddedFileProvider = new EmbeddedFileProvider(assembly);

            serviceCollection.Configure<MvcRazorRuntimeCompilationOptions>(options =>
            {
                options.FileProviders.Add(embeddedFileProvider);
            });
            return serviceCollection;
        }
    }
}
