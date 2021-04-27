using Blogging.Core.Extensions;
using Feedback.Core.Extensions;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IQTechSolutions.DataStores
{
    public class IQTechSolutionsDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Properties

        /// <summary>
        /// Generic DataSet to retrieve TEntity
        /// </summary>
        /// <typeparam name="TEntity">The Type the dataset returns</typeparam>
        /// <returns>DataSet of type TEntity</returns>
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

            modelBuilder.ApplySupportTicketConfiguration()
                .ApplyBloggingConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
