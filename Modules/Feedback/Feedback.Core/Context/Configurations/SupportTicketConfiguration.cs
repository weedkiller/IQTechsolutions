using Feedback.Base.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Feedback.Core.Context.Configurations
{
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class SupportTicketConfiguration : IEntityTypeConfiguration<SupportTicket>
    {
        public void Configure(EntityTypeBuilder<SupportTicket> builder)
        {
            builder.HasMany(c => c.Files).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.ChildTickets).WithOne(c => c.ParentTicket).HasForeignKey(c => c.ParentTicketId);
        }
    }
}
