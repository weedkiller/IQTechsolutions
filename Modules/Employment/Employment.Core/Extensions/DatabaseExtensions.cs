using Employment.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Employment.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplyEmploymentConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            return modelBuilder;
        }
    }
}
