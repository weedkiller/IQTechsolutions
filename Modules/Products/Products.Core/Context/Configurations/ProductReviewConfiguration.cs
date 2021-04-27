using Feedback.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Products.Base.Entities;

namespace Products.Core.Context.Configurations
{
    /// <summary>
    /// The database configuration for the service task entity
    /// </summary>
    public class ProductReviewConfiguration : IEntityTypeConfiguration<Comment<Product>>
    {
        public void Configure(EntityTypeBuilder<Comment<Product>> builder)
        {
            builder.HasOne(c => c.Entity).WithMany(c => c.Reviews).HasForeignKey(c => c.EntityId);
        }
    }
}
