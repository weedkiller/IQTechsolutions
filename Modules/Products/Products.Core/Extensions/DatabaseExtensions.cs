using Iqt.Inventory.Configurations;
using Microsoft.EntityFrameworkCore;
using Products.Core.Context.Configurations;

namespace Products.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyProductConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration())
                .ApplyConfiguration(new ProductBrandsConfiguration())
                .ApplyConfiguration(new ProductCategoryConfiguration())
                .ApplyConfiguration(new IncludedProductConfiguration())
                .ApplyConfiguration(new OptionalProductConfiguration())
                .ApplyConfiguration(new ProductComboConfiguration())
                .ApplyConfiguration(new ProductComboExclusionConfiguration())
                .ApplyConfiguration(new ProductDepartmentConfiguration())
                .ApplyConfiguration(new ProductReviewConfiguration());
            return modelBuilder;
        }
    }
}
