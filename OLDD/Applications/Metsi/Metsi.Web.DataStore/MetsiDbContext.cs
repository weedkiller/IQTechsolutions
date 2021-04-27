using System;
using System.Collections.Generic;
using System.Text;

namespace Metsi.Web.DataStore
{
    /// <inheritdoc cref="IDbContext" />
    /// <summary>
    /// The database representational model for our database
    /// </summary>
    public class MetsiDbContext : IdentityDbContext<ApplicationUser>, IDbContext
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
        public MetsiDbContext(DbContextOptions<MetsiDbContext> options) : base(options)
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
            // Base Implementation
            base.OnModelCreating(modelBuilder);

            // Configure Application User
            modelBuilder.Entity<ApplicationUser>().OwnsOne(p => p.SocialMedia);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.Friends).WithOne(c => c.User).HasForeignKey(c => c.UserId);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.SharedFolders).WithOne(c => c.Sharer).HasForeignKey(c => c.SharerId);
            modelBuilder.Entity<ApplicationUser>().HasMany(p => p.FoldersSharedWith).WithOne(c => c.SharedWith).HasForeignKey(c => c.SharedWithId);

            modelBuilder.ApplyTrainingCourseConfiguration()
                .ApplyProjectConfiguration()
                .ApplyServiceConfiguration()
                .ApplyBloggingConfiguration()
                .ApplyFaqConfiguration()
                .ApplyGalleryConfiguration()
                .ApplyFeedbackConfiguration()
                .ApplyCalenderConfiguration();

            // Configure Calender
            modelBuilder.ApplyConfiguration(new RecurringTaskConfiguration())
                .ApplyConfiguration(new AppointmentConfiguration());

            // Configure Messaging
            modelBuilder.ApplyConfiguration(new ChatConfiguration())
                .ApplyConfiguration(new ChatUserConfiguration())
                .ApplyConfiguration(new MessageConfiguration())
                .ApplyConfiguration(new NotificationConfiguration())
                .ApplyConfiguration(new TimelineItemConfiguration());

            modelBuilder.ApplyConfiguration(new BusinessConfiguration());

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

        }
    }
}
