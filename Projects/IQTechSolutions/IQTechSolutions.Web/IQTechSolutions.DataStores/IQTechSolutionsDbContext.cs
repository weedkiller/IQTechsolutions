using Blogging.Core.Extensions;
using Feedback.Core.Extensions;
using Identity.Base.Entities;
using InventoryManagement.Core.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Core.Extensions;
using Projects.Core.Extensions;
using Suppliers.Core.Extensions;

namespace IQTechSolutions.DataStores
{
    public class IQTechSolutionsDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public IQTechSolutionsDbContext(DbContextOptions<IQTechSolutionsDbContext> options) : base(options)
        {
        }

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Overrides OnModelCreating to add property annotations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasOne(c => c.UserInfo).WithOne().HasForeignKey<ApplicationUser>(v => v.Id);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);

            modelBuilder.ApplySupportTicketConfiguration().ApplyBloggingConfiguration()
                .ApplyProjectConfiguration().ApplyInventoryManagementConfiguration()
                .ApplySupplierConfiguration().ApplyProductConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
