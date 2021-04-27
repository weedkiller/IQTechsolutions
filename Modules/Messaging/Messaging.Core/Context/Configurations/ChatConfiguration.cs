using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messaging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class ChatConfiguration : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            builder.HasMany(c => c.Messages).WithOne(c => c.Chat).HasForeignKey(c => c.ChatId);
            builder.HasMany(c => c.Users).WithOne(c => c.Chat).HasForeignKey(c => c.ChatId);
        }
    }
}
