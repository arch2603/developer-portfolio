using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;

public sealed class ExperienceTechnologyConfiguration
    : IEntityTypeConfiguration<ExperienceTechnology>
{
    public void Configure(EntityTypeBuilder<ExperienceTechnology> b)
    {
        b.ToTable("experience_technologies");

        b.HasKey(x => new { x.ExperienceId, x.TechnologyId });

        b.HasOne(x => x.Experience)
            .WithMany(x => x.ExperienceTechnologies)
            .HasForeignKey(x => x.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasOne(x => x.Technology)
            .WithMany(x => x.ExperienceTechnologies)
            .HasForeignKey(x => x.TechnologyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}