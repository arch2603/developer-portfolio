using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;

public sealed class AboutProfileConfiguration
    : IEntityTypeConfiguration<AboutProfile>
{
    public void Configure(EntityTypeBuilder<AboutProfile> b)
    {
        b.ToTable("about_profiles");

        b.HasKey(x => x.Id);

        b.Property(x => x.Heading)
            .HasMaxLength(160)
            .IsRequired();

        b.Property(x => x.Introduction)
            .HasMaxLength(600)
            .IsRequired();

        b.Property(x => x.Biography)
            .IsRequired();

        b.Property(x => x.Location)
            .HasMaxLength(160)
            .IsRequired();

        b.Property(x => x.Availability)
            .HasMaxLength(300)
            .IsRequired();

        b.Property(x => x.UpdatedUtc)
            .HasColumnType("timestamptz");
    }
}