using Microsoft.EntityFrameworkCore;
using Shopping.Core.Context.Configurations;

namespace Shopping.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyShoppingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            return modelBuilder;
        }
    }
}
