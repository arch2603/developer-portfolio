using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Domain.Entities;

namespace Portfolio.Api.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(PortfolioDbContext db, CancellationToken ct = default)
    {
        if (!await db.Projects.AnyAsync(ct))
        {
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

        if (!await db.AboutProfiles.AnyAsync(ct))
        {
            db.AboutProfiles.Add(new AboutProfile
            {
                Heading = "About Me",

                Introduction =
                    "I’m a Brisbane-based software developer and IT professional with experience building, supporting, and deploying web applications, APIs, databases, and business systems across a range of environments.",

                Biography =
                    """
                    My development experience spans ASP.NET Core/.NET, Java, PHP/Laravel, React, TypeScript, JavaScript, SQL, PostgreSQL, MySQL, SQL Server, REST APIs, and cloud deployment on AWS. I enjoy working across the application lifecycle — from understanding business requirements and designing database structures through to backend development, frontend integration, testing, troubleshooting, deployment, and production support.

                    Most recently, I designed and deployed this portfolio as a full-stack application using ASP.NET Core Web API, React, TypeScript, PostgreSQL, Entity Framework Core, Nginx, AWS EC2, Cloudflare, and HTTPS. The project includes REST API endpoints, relational database integration, service-layer architecture, health checks, rate limiting, responsive frontend development, and production deployment.

                    I have also developed a Payroll Management System using React, Express.js, PostgreSQL, and AWS, covering employee management, pay periods, payroll processing, validations, bank-file generation, authentication, and PDF payslips.

                    Professionally, I have worked across software development, systems analysis, IT operations, technical support, and technology leadership. At Our Property in Brisbane, I worked in an Agile development environment using PHP/Laravel, React, JavaScript, REST APIs, OAuth2, two-factor authentication, and relational databases. My work included customer-facing and internal applications, API development, production support, debugging, SQL analysis, code reviews, and CI/CD processes.

                    Earlier roles gave me experience across enterprise systems, databases, reporting, infrastructure, technical support, systems analysis, and business applications. This broader IT background helps me approach software not just as code, but as part of a larger operational environment involving users, data, security, infrastructure, and business processes.

                    I hold a Bachelor of Information Technology in Computer Science from QUT, along with qualifications in Commerce/Accounting and Telecommunications Engineering, and have completed Cisco CCNA training.

                    I’m particularly interested in full-stack and backend engineering, cloud development, DevOps, secure application development, system integration, automation, and scalable business software. I continue to expand my skills across C#/.NET, Java/Spring Boot, Angular, TypeScript, Docker, AWS, CI/CD, Kubernetes, and DevSecOps.

                    I enjoy solving practical problems, learning new technologies, and turning requirements into reliable software that is secure, maintainable, and useful.
                    """,

                Location = "Brisbane, Queensland",

                Availability =
                    "Open to software development opportunities.",

                UpdatedUtc = DateTime.UtcNow,

                Capabilities =
                [
                    new() { Name = "C# / ASP.NET Core / .NET", DisplayOrder = 1 },
                    new() { Name = "Java / Spring Boot", DisplayOrder = 2 },
                    new() { Name = "PHP / Laravel", DisplayOrder = 3 },
                    new() { Name = "React / TypeScript / JavaScript", DisplayOrder = 4 },
                    new() { Name = "REST API Design & Integration", DisplayOrder = 5 },
                    new() { Name = "PostgreSQL / MySQL / SQL Server", DisplayOrder = 6 },
                    new() { Name = "Entity Framework Core", DisplayOrder = 7 },
                    new() { Name = "AWS / Linux / Nginx / Cloudflare", DisplayOrder = 8 },
                    new() { Name = "Docker / CI/CD / Git", DisplayOrder = 9 },
                    new() { Name = "Authentication / OAuth2 / 2FA", DisplayOrder = 10 },
                    new() { Name = "Application Support & Troubleshooting", DisplayOrder = 11 },
                    new() { Name = "Systems Analysis & Database Design", DisplayOrder = 12 }
                ]
            });
        }

        await db.SaveChangesAsync(ct);
    }
}