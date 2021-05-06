using Identity.Base;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Core.Extensions;
using Shopping.Core.Extensions;

namespace GoldTechInnovation.DataStore
{
    /// <inheritdoc cref="DbContext" />
    /// <summary>
    /// The database representational model for our database
    /// </summary>
    public class GoldTechInnovationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public GoldTechInnovationDbContext(DbContextOptions<GoldTechInnovationDbContext> options) : base(options)
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
            modelBuilder.Entity<ApplicationUser>().HasOne(c => c.UserInfo).WithOne().HasForeignKey<ApplicationUser>(v => v.Id);

            modelBuilder.Entity<UserInfo>().HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.ContactNumbers).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.EmailAddresses).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);
            modelBuilder.Entity<UserInfo>().HasMany(c => c.Addresses).WithOne(c => c.Entity).HasForeignKey(v => v.EntityId);

            // Configure Services
            modelBuilder.ApplyProductConfiguration().ApplyShoppingConfiguration();
        }
    }
}