using Messaging.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Messaging.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Company entity
    /// </summary>
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasOne(c => c.Sender).WithMany().HasForeignKey(c => c.SenderId);
            builder.HasOne(c => c.Receiver).WithMany().HasForeignKey(c => c.ReceiverId);
            builder.HasOne(c => c.Chat).WithMany(c => c.Messages).HasForeignKey(c => c.ChatId);
        }
    }
}
