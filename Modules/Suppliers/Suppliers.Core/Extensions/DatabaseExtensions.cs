using Customers.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Suppliers.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplySupplierConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            return modelBuilder;
        }
    }
}
