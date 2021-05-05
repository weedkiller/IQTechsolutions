using InventoryManagement.Core.Context.Configurations.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Core.Extensions
{
    /// <summary>
    /// The module extension methods
    /// </summary>
    public static class ModuleExtensions
    {
        /// <summary>
        /// Adds the Good Received Vouchers Module services to the application
        /// </summary>
        /// <param name="serviceCollection">The injected service collection these services should be added to</param>
        /// <returns>The injected service collection</returns>
        public static IServiceCollection AddInventoryManagementModule(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<GoodReceivedVoucherContext>();
            
            return serviceCollection;
        }
    }
}
