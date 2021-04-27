using Microsoft.Extensions.DependencyInjection;
using Products.Base.Api.Services;

namespace Products.Base.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddProductServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ProductCategoriesApiService>();
            return serviceCollection;
        }
    }
}
