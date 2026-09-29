using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data.Configurations;

public sealed class AboutCapabilityConfiguration
    : IEntityTypeConfiguration<AboutCapability>
{
    public void Configure(EntityTypeBuilder<AboutCapability> b)
    {
        b.ToTable("about_capabilities");

        b.HasKey(x => x.Id);

        b.Property(x => x.Name)
            .HasMaxLength(160)
            .IsRequired();

        b.HasOne(x => x.AboutProfile)
            .WithMany(x => x.Capabilities)
            .HasForeignKey(x => x.AboutProfileId)
            .OnDelete(DeleteBehavior.Cascade);

        b.HasIndex(x => new
        {
            x.AboutProfileId,
            x.DisplayOrder
        });
    }
}