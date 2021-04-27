using Microsoft.EntityFrameworkCore;
using Projects.Core.Context.Configurations;

namespace Projects.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyProjectConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectConfiguration())
                .ApplyConfiguration(new ProjectCategoryConfiguration());
            return modelBuilder;
        }
    }
}
