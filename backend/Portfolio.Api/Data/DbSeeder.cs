using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data;
public static class DbSeeder
{
    public static async Task SeedAsync(PortfolioDbContext db, CancellationToken ct = default)
    {
        if (!await db.Projects.AnyAsync(ct)) {
            var react = new Technology { Name = "React", Slug = "react" };
            var dotnet = new Technology { Name = ".NET", Slug = "dotnet" };
            var postgres = new Technology { Name = "PostgreSQL", Slug = "postgresql" };
            db.Projects.Add(new Project
            {
                Slug = "developer-portfolio",
                Title = "Full-Stack Developer Portfolio",
                Summary = "A production-deployed React and ASP.NET Core portfolio.",
                Description = "A case study in API design, relational modelling, deployment, and operations.",
                RepositoryUrl = "https://github.com/arch2603/developer-portfolio",
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
        }

        if (!await db.AboutProfiles.AnyAsync(ct)) {   
            db.AboutProfiles.Add(new AboutProfile
            {
                Heading = "About Me",

                Introduction =
                    "Full-stack software developer based in Brisbane, building reliable web applications across frontend, backend, databases, and cloud infrastructure.",

                Biography =
                    "I have experience developing and supporting business applications using technologies including ASP.NET Core, React, TypeScript, PHP, Laravel, Java, SQL, and PostgreSQL. My work spans REST API development, relational database design, authentication, production support, and cloud deployment. I enjoy solving practical business problems and building software that is maintainable, secure, and reliable.",

                Location = "Brisbane, Queensland",

                Availability =
                    "Open to software development opportunities.",

                UpdatedUtc = DateTime.UtcNow,

                Capabilities =
                [
                    new()
                    {
                        Name = "React and TypeScript",
                        DisplayOrder = 1
                    },
                    new()
                    {
                        Name = "C# and ASP.NET Core",
                        DisplayOrder = 2
                    },
                    new()
                    {
                        Name = "PostgreSQL and EF Core",
                        DisplayOrder = 3
                    },
                    new()
                    {
                        Name = "REST APIs and relational database design",
                        DisplayOrder = 4
                    },
                    new()
                    {
                        Name = "AWS, Linux, Nginx and Cloudflare",
                        DisplayOrder = 5
                    }
                ]
            });
        }
        
        await db.SaveChangesAsync(ct);
    }
}