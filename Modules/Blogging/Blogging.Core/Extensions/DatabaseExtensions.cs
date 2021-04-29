using Blogging.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyBloggingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaseStucyConfiguration())
                .ApplyConfiguration(new CaseStudyCategoryConfiguration());
            return modelBuilder;
        }

        public static ModelBuilder ApplyCaseStudyConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CaseStucyConfiguration())
                .ApplyConfiguration(new CaseStudyCategoryConfiguration());
            return modelBuilder;
        }
    }
}
