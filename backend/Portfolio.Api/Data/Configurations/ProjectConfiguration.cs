using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;
public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> b)
    {
        b.ToTable("projects");
        b.HasKey(x => x.Id);
        b.Property(x => x.Slug).HasMaxLength(120).IsRequired();
        b.HasIndex(x => x.Slug).IsUnique();
        b.Property(x => x.Title).HasMaxLength(160).IsRequired();
        b.Property(x => x.Summary).HasMaxLength(400).IsRequired();
        b.Property(x => x.Description).IsRequired();
        b.Property(x => x.RepositoryUrl).HasMaxLength(500);
        b.Property(x => x.LiveUrl).HasMaxLength(500);
        b.Property(x => x.CreatedUtc).HasColumnType("timestamptz");
        b.HasIndex(x => new { x.IsPublished, x.DisplayOrder });
    }
}