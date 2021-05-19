using Blogging.Core.Extensions;
using Identity.Base.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Core.Extensions;

namespace GoldTechInnovation.DataStore
{
    public class GoldTechInnovationDbContext : IdentityDbContext<ApplicationUser>
    {
        /// <inheritdoc />
        /// <summary>
        /// Default constructor, expecting database options passed in
        /// </summary>
        /// <param name="options">The database context options</param>
        public GoldTechInnovationDbContext(DbContextOptions<GoldTechInnovationDbContext> options) : base(options)
        {
        }

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
            
            modelBuilder.ApplyBloggingConfiguration().ApplyProductConfiguration();

            base.OnModelCreating(modelBuilder);
        }
    }
}
