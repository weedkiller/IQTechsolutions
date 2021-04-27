using Microsoft.EntityFrameworkCore;
using Services.Core.Context.Configurations;

namespace Services.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyServiceConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceConfiguration())
                .ApplyConfiguration(new ServiceTaskConfiguration())
                .ApplyConfiguration(new ServiceCategoryConfiguration())
                .ApplyConfiguration(new IncludedServiceConfiguration())
                .ApplyConfiguration(new OptionalServiceConfiguration())
                .ApplyConfiguration(new ServiceComboConfiguration())
                .ApplyConfiguration(new ServiceComboExclusionConfiguration());
            return modelBuilder;
        }
    }
}
