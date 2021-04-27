using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Troubleshooting.Base.Entities;

namespace Troubleshooting.Core.Context.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the product entity
    /// </summary>
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasMany(c => c.Answers).WithOne(c => c.Question).HasForeignKey(c => c.QuestionId);
            builder.HasMany(c => c.Categories).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
        }
    }
}
