using Feedback.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class NewsFeedConfiguration : IEntityTypeConfiguration<NewsFeed>
    {
        public void Configure(EntityTypeBuilder<NewsFeed> builder)
        {
            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.ParentFeed).WithMany(c => c.Comments).HasForeignKey(c => c.ParentFeedId);

            builder.HasMany(c => c.FeedFeelings).WithOne();

            builder.HasMany(c => c.Comments).WithOne(c => c.ParentFeed).HasForeignKey(c => c.ParentFeedId);
            builder.HasMany(c => c.Files).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.AudioFiles).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Videos).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
