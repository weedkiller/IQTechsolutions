using Blogging.Core.Extensions;
using Customers.Core.Extensions;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Core.Extensions;
using Services.Core.Extensions;
using Shopping.Core.Extensions;
using Troubleshooting.Core.Extensions;

namespace FeawThings.Web.Datastore
{
    public class FeawThingsDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        /// <summary>
        /// Generic DataSet to retrieve TEntity
        /// </summary>
        /// <typeparam name="TEntity">The Type the data set returns</typeparam>
        /// <returns>Dataset of type TEntity</returns>
        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        #endregion

        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public FeawThingsDbContext(DbContextOptions<FeawThingsDbContext> options) : base(options)
        {
        }

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Overrides on model creating to add property annotations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>().HasOne(c => c.UserInfo).WithOne().HasForeignKey<ApplicationUser>(v => v.Id);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);

            modelBuilder.ApplyFaqConfiguration().ApplyServiceConfiguration()
                .ApplyBloggingConfiguration().ApplyCustomerConfiguration()
                .ApplyProductConfiguration().ApplyShoppingConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
