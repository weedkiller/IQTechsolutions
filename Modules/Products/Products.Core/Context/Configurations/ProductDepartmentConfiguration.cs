using Grouping.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ProductDepartmentConfiguration : IEntityTypeConfiguration<Department<Product>>
    {
        public void Configure(EntityTypeBuilder<Department<Product>> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Categories).WithOne(c => c.Department).HasForeignKey(c => c.DepartmentId);
        }
    }
}
