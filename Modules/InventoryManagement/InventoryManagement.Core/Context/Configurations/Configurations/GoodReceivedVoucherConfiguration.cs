using InventoryManagement.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Core.Context.Configurations.Configurations
{
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class GoodReceivedVoucherConfiguration : IEntityTypeConfiguration<GoodReceivedVoucher>
    {
        public void Configure(EntityTypeBuilder<GoodReceivedVoucher> builder)
        {
            builder.HasOne(c => c.Supplier).WithMany().HasForeignKey("SupplierId");

            builder.HasMany(c => c.Details)
                .WithOne(c => c.GoodReceivedVoucher)
                .HasForeignKey(c => c.GoodReceivedVoucherId);
        }
    }
}
