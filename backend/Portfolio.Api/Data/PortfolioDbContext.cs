using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data;

public sealed class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options)
    : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<Technology> Technologies => Set<Technology>();
    public DbSet<ProjectTechnology> ProjectTechnologies => Set<ProjectTechnology>();
    public DbSet<ContactMessage> ContactMessages => Set<ContactMessage>();
    public DbSet<AboutProfile> AboutProfiles => Set<AboutProfile>();
    public DbSet<AboutCapability> AboutCapabilities => Set<AboutCapability>();
    public DbSet<Experience> Experiences => Set<Experience>();
    public DbSet<ExperienceHighlight> ExperienceHighlights => Set<ExperienceHighlight>();
    public DbSet<ExperienceTechnology> ExperienceTechnologies => Set<ExperienceTechnology>();
    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PortfolioDbContext).Assembly);
}