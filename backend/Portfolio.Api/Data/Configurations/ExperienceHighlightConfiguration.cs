using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;

public sealed class ExperienceHighlightConfiguration
    : IEntityTypeConfiguration<ExperienceHighlight>
{
    public void Configure(EntityTypeBuilder<ExperienceHighlight> b)
    {
        b.ToTable("experience_highlights");

        b.HasKey(x => x.Id);

        b.Property(x => x.Text)
            .HasMaxLength(500)
            .IsRequired();

        b.HasOne(x => x.Experience)
            .WithMany(x => x.Highlights)
            .HasForeignKey(x => x.ExperienceId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new { x.ExperienceId, x.DisplayOrder });
    }
}