using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data;
public static class DbSeeder
{
    public static async Task SeedAsync(PortfolioDbContext db, CancellationToken ct = default)
    {
        if (await db.Projects.AnyAsync(ct)) return;
        var react = new Technology { Name = "React", Slug = "react" };
        var dotnet = new Technology { Name = ".NET", Slug = "dotnet" };
        var postgres = new Technology { Name = "PostgreSQL", Slug = "postgresql" };
        db.Projects.Add(new Project
        {
            Slug = "developer-portfolio",
            Title = "Full-Stack Developer Portfolio",
            Summary = "A production-deployed React and ASP.NET Core portfolio.",
            Description = "A case study in API design, relational modelling, deployment, and operations.",
            RepositoryUrl = "https://github.com/YOUR-NAME/developer-portfolio",
            IsFeatured = true,
            IsPublished = true,
            DisplayOrder = 1,
            ProjectTechnologies =
            [
                new() { Technology = react },
                new() { Technology = dotnet },
                new() { Technology = postgres }
            ]
        });
        await db.SaveChangesAsync(ct);
    }
}