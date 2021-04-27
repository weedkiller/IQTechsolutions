using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messaging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class ChatUserConfiguration : IEntityTypeConfiguration<ChatUser>
    {
        public void Configure(EntityTypeBuilder<ChatUser> builder)
        {
            builder.HasKey(sc => new { sc.ChatId, sc.UserId });

            builder.HasOne(c => c.Chat).WithMany(c => c.Users).HasForeignKey(c => c.ChatId);
            builder.HasOne(c => c.User).WithMany().HasForeignKey(c => c.UserId);
        }
    }
}
