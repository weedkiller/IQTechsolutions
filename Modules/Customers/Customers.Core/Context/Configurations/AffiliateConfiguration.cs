using Customers.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customers.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Customer entity
    /// </summary>
    public class AffiliateConfiguration : IEntityTypeConfiguration<Affiliate>
    {
        public void Configure(EntityTypeBuilder<Affiliate> builder)
        {

        }
    }
}
