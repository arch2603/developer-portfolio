using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;
public sealed class ProjectTechnologyConfiguration : IEntityTypeConfiguration<ProjectTechnology>
{
    public void Configure(EntityTypeBuilder<ProjectTechnology> b)
    {
        b.ToTable("project_technologies");
        b.HasKey(x => new { x.ProjectId, x.TechnologyId });
        b.HasOne(x => x.Project).WithMany(x => x.ProjectTechnologies)
            .HasForeignKey(x => x.ProjectId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Technology).WithMany(x => x.ProjectTechnologies)
            .HasForeignKey(x => x.TechnologyId).OnDelete(DeleteBehavior.Restrict);
    }
}