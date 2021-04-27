using Blogging.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyBloggingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BlogPostConfiguration())
                .ApplyConfiguration(new BlogCategoryConfiguration());
            return modelBuilder;
        }
    }
}
