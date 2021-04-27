using Iqt.Troubleshooting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Iqt.Troubleshooting.Configurations
{
    /// <inheritdoc />
    /// <summary>
    /// The database configuration for the Answer entity
    /// </summary>
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasOne(c => c.Question).WithMany(c => c.Answers).HasForeignKey(c => c.QuestionId);
        }
    }
}
