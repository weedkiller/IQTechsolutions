using Iqt.Blogging.Extensions;
using Iqt.Calender.Entities;
using Iqt.Calender.Extensions;
using Iqt.Commerce.Configurations;
using Iqt.Employment.Configurations;
using Iqt.Feedback.Configurations;
using Iqt.Gallery.Extensions;
using Iqt.Identity.Entities;
using Iqt.Inventory.Extensions;
using Iqt.ServiceRegistry.Extensions;
using Iqt.Social.Configurations;
using Iqt.Social.Entities;
using Iqt.Training.Extensions;
using Iqt.Troubleshooting.Extensions;
using IQTechFramework.DataStore.Configurations;
using IQTechFramework.Entities.Application;
using IQTechSolutions.Base.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KingdomLifestyleMinistries.Web.DataStore
{
    /// <inheritdoc cref="IDbContext" />
    /// <summary>
    /// The database representational model for our database
    /// </summary>
    public class KingdomLifestyleMinistriesDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        #region Public Properties

        /// <summary>
        /// The settings for the application
        /// </summary>
        public DbSet<Setting> Settings { get; set; }
        
        /// <inheritdoc />
        /// <summary>
        /// Generic DataSet to retrieve TEntity
        /// </summary>
        /// <typeparam name="TEntity">The Type the dataset returns</typeparam>
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
        public KingdomLifestyleMinistriesDbContext(DbContextOptions<KingdomLifestyleMinistriesDbContext> options) : base(options)
        {
        }

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Overrides onmodelcreating to add property annotations
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Base Implimentation
            base.OnModelCreating(modelBuilder);

            // Configure Application User
            modelBuilder.Entity<ApplicationUser>().OwnsOne(p => p.SocialMedia);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.Friends).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.SharedFolders).WithOne(c => c.Sharer).HasForeignKey(c => c.SharerId);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.FoldersSharedWith).WithOne(c => c.SharedWith).HasForeignKey(c => c.SharedWithId);

            modelBuilder.Entity<GuestSpeaker>().Property(c => c.Description).HasMaxLength(2000);

            // Configure Services
            modelBuilder.ApplyServiceConfiguration()
                .ApplyInventoryConfiguration()
                .ApplyBloggingConfiguration()
                .ApplyGalleryConfiguration()
                .ApplyFaqConfiguration()
                .ApplyCalenderConfiguration()
                .ApplyTrainingCourseConfiguration();

            modelBuilder.ApplyConfiguration(new PreacherConfiguration());

            modelBuilder.ApplyConfiguration(new BusinessConfiguration())
                .ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder.ApplyConfiguration(new VehicleConfiguration());
            modelBuilder.ApplyConfiguration(new ShoppingCartItemConfiguration());
            modelBuilder.ApplyConfiguration(new SupportTicketConfiguration());
        }
    }
}