using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projects.Base.Entities;

namespace Projects.Core.Context.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(c => c.ProjectName).HasMaxLength(250);
            builder.HasMany(c => c.Images).WithOne(c => c.Entity).HasForeignKey(c => c.EntityId);
            builder.HasMany(c => c.LinkedProjects).WithOne(c => c.ParentProject).HasForeignKey(c => c.ParentProjectId);
        }
    }
}
