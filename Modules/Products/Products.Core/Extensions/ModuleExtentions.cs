using Microsoft.Extensions.DependencyInjection;
using Products.Core.Context.Services;

namespace Products.Core.Extensions
{
    public static class ModuleExtensions
    {
        public static IServiceCollection AddProducts(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProductContext>();
            serviceCollection.AddTransient<BrandContext>();
            return serviceCollection;
        }
    }
}
