using InventoryManagement.Core.Context.Configurations.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyInventoryManagementConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GoodReceivedVoucherConfiguration());
            return modelBuilder;
        }
    }
}
