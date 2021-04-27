using Customers.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Customers.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyCustomerConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            return modelBuilder;
        }

        public static ModelBuilder ApplyAffiliateConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AffiliateConfiguration());
            return modelBuilder;
        }
    }
}
