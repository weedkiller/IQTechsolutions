using Blogging.Core.Extensions;
using Calendar.Core.Extensions;
using Customers.Core.Extensions;
using Employment.Core.Extensions;
using Feedback.Core.Extensions;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Projects.Core.Extensions;
using Services.Core.Extensions;
using Troubleshooting.Core.Extensions;

namespace Olympia.Web.DataStore
{
    public class OlympiaDbContext : IdentityDbContext<ApplicationUser>
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
        public OlympiaDbContext(DbContextOptions<OlympiaDbContext> options) : base(options)
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
            modelBuilder.Entity<UserInfo>().HasMany(c => c.ContactNumbers).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.EmailAddresses).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.Addresses).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);


            modelBuilder.ApplySupportTicketConfiguration()
                .ApplyTroubleshootingConfiguration()
                .ApplyFaqConfiguration().ApplyServiceConfiguration()
                .ApplyBloggingConfiguration().ApplyProjectConfiguration()
                .ApplyEmploymentConfiguration().ApplyCustomerConfiguration()
                .ApplyCalenderConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
