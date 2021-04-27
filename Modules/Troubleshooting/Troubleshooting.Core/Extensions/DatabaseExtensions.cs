using Microsoft.EntityFrameworkCore;
using Troubleshooting.Core.Context.Configurations;

namespace Troubleshooting.Core.Extensions
{
    public static class DatabaseExtensions
    {
        /// <summary>
        /// Applies the Faq Entities configurations to the database modal
        /// </summary>
        /// <param name="modelBuilder">The model builder of the framework</param>
        /// <returns>The modalbuilder for chaining</returns>
        public static ModelBuilder ApplyFaqConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FaqCategoryConfiguration())
                .ApplyConfiguration(new QuestionConfiguration())
                .ApplyConfiguration(new AnswerConfiguration());
            return modelBuilder;
        }

        /// <summary>
        /// Applies the Trouble Shooting Entities configurations to the database modal
        /// </summary>
        /// <param name="modelBuilder">The model builder of the framework</param>
        /// <returns>The modalbuilder for chaining</returns>
        public static ModelBuilder ApplyTroubleshootingConfiguration(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProblemCategoryConfiguration())
                .ApplyConfiguration(new ProblemConfiguration())
                .ApplyConfiguration(new CauseConfiguration())
                .ApplyConfiguration(new CorrectiveActionConfiguration());
            return modelBuilder;
        }
    }
}
