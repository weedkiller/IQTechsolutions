using Feedback.Core.Context.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Core.Extensions
{
    public static class DatabaseExtensions
    {
        public static ModelBuilder ApplySupportTicketConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupportTicketConfiguration()).ApplyConfiguration(new NewsFeedConfiguration()).ApplyConfiguration(new TestimonialConfiguration());
            return modelBuilder;
        }
    }
}
