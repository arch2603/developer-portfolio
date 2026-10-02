using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;

public sealed class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> b)
    {
        b.ToTable("experiences");

        b.HasKey(x => x.Id);

        b.Property(x => x.Company)
            .HasMaxLength(160)
            .IsRequired();

        b.Property(x => x.Role)
            .HasMaxLength(160)
            .IsRequired();

        b.Property(x => x.Location)
            .HasMaxLength(160)
            .IsRequired();

        b.Property(x => x.StartDate)
            .HasColumnType("date");

        b.Property(x => x.EndDate)
            .HasColumnType("date");

        b.Property(x => x.Summary)
            .HasMaxLength(1000)
            .IsRequired();

        b.HasIndex(x => new { x.IsPublished, x.DisplayOrder });
    }
}