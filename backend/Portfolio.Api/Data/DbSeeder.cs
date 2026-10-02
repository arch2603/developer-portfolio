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

        if (!await db.Experiences.AnyAsync(x => x.Company == "Our Property" && x.Role == "Software Developer", ct))
        {
            var php = await GetOrCreateTechnologyAsync(
                db, "PHP", "php", ct);

            var laravel = await GetOrCreateTechnologyAsync(
                db, "Laravel", "laravel", ct);

            var react = await GetOrCreateTechnologyAsync(
                db, "React", "react", ct);

            var javascript = await GetOrCreateTechnologyAsync(
                db, "JavaScript", "javascript", ct);

            var sqlServer = await GetOrCreateTechnologyAsync(
                db, "SQL Server", "sql-server", ct);

            var mysql = await GetOrCreateTechnologyAsync(
                db, "MySQL", "mysql", ct);

            var postgresql = await GetOrCreateTechnologyAsync(
                db, "PostgreSQL", "postgresql", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Our Property",
                Role = "Software Developer",
                Location = "Brisbane, Queensland",
                StartDate = new DateOnly(2021, 1, 1),
                EndDate = new DateOnly(2022, 2, 1),
                IsCurrent = false,

                Summary =
                    "Developed and supported customer-facing and internal web applications in an Agile development environment, working across backend development, frontend implementation, APIs, databases, authentication, troubleshooting, and production support.",

                DisplayOrder = 1,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Developed and maintained web applications using PHP, Laravel, React and JavaScript.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Developed and integrated REST APIs supporting customer-facing and internal application functionality.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Worked with OAuth2 and two-factor authentication as part of secure application authentication and access workflows.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Investigated production issues using application logs, debugging and SQL analysis across relational databases.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Participated in Agile development, code reviews, testing, production support and CI/CD processes.",
                DisplayOrder = 5
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = php },
            new() { Technology = laravel },
            new() { Technology = react },
            new() { Technology = javascript },
            new() { Technology = sqlServer },
            new() { Technology = mysql },
            new() { Technology = postgresql }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Samoa Qualifications Authority" &&
             x.Role == "Software Developer (Contract)",
        ct))
        {
            var php = await GetOrCreateTechnologyAsync(
                db, "PHP", "php", ct);

            var mysql = await GetOrCreateTechnologyAsync(
                db, "MySQL", "mysql", ct);

            var javascript = await GetOrCreateTechnologyAsync(
                db, "JavaScript", "javascript", ct);

            var jquery = await GetOrCreateTechnologyAsync(
                db, "jQuery", "jquery", ct);

            var bootstrap = await GetOrCreateTechnologyAsync(
                db, "Bootstrap", "bootstrap", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Samoa Qualifications Authority",
                Role = "Software Developer (Contract)",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2020, 6, 1),
                EndDate = new DateOnly(2021, 4, 1),
                IsCurrent = false,

                Summary =
                    "Developed and supported web-based business applications for the Samoa Qualifications Authority using PHP, MySQL and client-side web technologies.",

                DisplayOrder = 2,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Developed and maintained web application functionality using PHP and MySQL.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Implemented client-side functionality and user-interface components using JavaScript, jQuery and Bootstrap.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Worked with relational data and application functionality supporting organisational business processes.",
                DisplayOrder = 3
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = php },
            new() { Technology = mysql },
            new() { Technology = javascript },
            new() { Technology = jquery },
            new() { Technology = bootstrap }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Ausjet Inks & Laser Supplies" &&
             x.Role == "IT Officer",
        ct))
        {
            var sqlServer = await GetOrCreateTechnologyAsync(
                db, "SQL Server", "sql-server", ct);

            var mysql = await GetOrCreateTechnologyAsync(
                db, "MySQL", "mysql", ct);

            var crystalReports = await GetOrCreateTechnologyAsync(
                db, "Crystal Reports", "crystal-reports", ct);

            var restApi = await GetOrCreateTechnologyAsync(
                db, "REST API", "rest-api", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Ausjet Inks & Laser Supplies",
                Role = "IT Officer",
                Location = "Cleveland, Queensland",
                StartDate = new DateOnly(2018, 4, 1),
                EndDate = new DateOnly(2019, 1, 1),
                IsCurrent = false,

                Summary =
                    "Supported and maintained business systems, databases, reporting and e-commerce operations, providing technical support and working with data integrations across operational systems.",

                DisplayOrder = 3,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Supported business applications and IT systems used in day-to-day company operations.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Worked with Neto CMS and REST API integrations supporting e-commerce operations.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Worked with SQL Server and MySQL databases for business data and application support.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Supported business reporting using Crystal Reports and worked with MYOB-related business processes.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Provided troubleshooting and technical support across business applications and IT systems.",
                DisplayOrder = 5
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = sqlServer },
            new() { Technology = mysql },
            new() { Technology = crystalReports },
            new() { Technology = restApi }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Electric Power Corporation" &&
             x.Role == "Chief Information Technology",
        ct))
        {
            var sqlServer = await GetOrCreateTechnologyAsync(
                db, "SQL Server", "sql-server", ct);

            var db2 = await GetOrCreateTechnologyAsync(
                db, "DB2", "db2", ct);

            var sybase = await GetOrCreateTechnologyAsync(
                db, "Sybase", "sybase", ct);

            var windowsServer = await GetOrCreateTechnologyAsync(
                db, "Windows Server", "windows-server", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Electric Power Corporation",
                Role = "Chief Information Technology",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2010, 3, 1),
                EndDate = new DateOnly(2011, 1, 1),
                IsCurrent = false,

                Summary =
                    "Led information technology operations, systems improvement, staff development, technology procurement and IT planning for Samoa's state-owned electricity utility.",

                DisplayOrder = 4,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Led reviews of existing systems and methods and contributed to the formulation of new and revised information systems.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Managed IT personnel and technicians and oversaw staff training and development needs relating to current and proposed systems.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Oversaw the Information Technology budget and provided guidance on technology cost and productivity analysis.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Negotiated with suppliers and coordinated procurement and contract renewals for hardware and software.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Provided guidance to management on objectives and requirements for existing and proposed information systems and the design of improved systems.",
                DisplayOrder = 5
            },
            new()
            {
                Text = "Worked with Human Resources on technology-related staffing requirements, position reviews and organisational needs.",
                DisplayOrder = 6
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = sqlServer },
            new() { Technology = db2 },
            new() { Technology = sybase },
            new() { Technology = windowsServer }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Electric Power Corporation" &&
             x.Role == "Information System Analyst",
        ct))
        {
            var sqlServer = await GetOrCreateTechnologyAsync(
                db, "SQL Server", "sql-server", ct);

            var db2 = await GetOrCreateTechnologyAsync(
                db, "DB2", "db2", ct);

            var sybase = await GetOrCreateTechnologyAsync(
                db, "Sybase", "sybase", ct);

            var windowsServer = await GetOrCreateTechnologyAsync(
                db, "Windows Server", "windows-server", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Electric Power Corporation",
                Role = "Information System Analyst",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2008, 9, 1),
                EndDate = new DateOnly(2010, 3, 1),
                IsCurrent = false,

                Summary =
                    "Analysed business systems and workflows, designed and implemented information-system improvements, led application programming activities, and supported the introduction of new technology across the organisation.",

                DisplayOrder = 5,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Analysed existing systems, procedures, data inputs and workflows to identify economical and feasible opportunities for improvement and standardisation.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Authored and produced the organisation's IT Disaster Recovery Plan.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Designed and implemented integrated hardware and software information systems to meet organisational requirements.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Oversaw implementation of new systems and provided training to users.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Evaluated requirements and recommended new computer equipment and software packages.",
                DisplayOrder = 5
            },
            new()
            {
                Text = "Led application programming activities including coding, testing, debugging, documentation and modification.",
                DisplayOrder = 6
            },
            new()
            {
                Text = "Supervised professional and technical support staff involved in information systems and IT operations.",
                DisplayOrder = 7
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = sqlServer },
            new() { Technology = db2 },
            new() { Technology = sybase },
            new() { Technology = windowsServer }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Electric Power Corporation" &&
             x.Role == "Senior Computer Technician",
        ct))
        {
            var windowsServer = await GetOrCreateTechnologyAsync(
                db, "Windows Server", "windows-server", ct);

            var activeDirectory = await GetOrCreateTechnologyAsync(
                db, "Active Directory", "active-directory", ct);

            var networking = await GetOrCreateTechnologyAsync(
                db, "Networking", "networking", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Electric Power Corporation",
                Role = "Senior Computer Technician",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2006, 7, 1),
                EndDate = new DateOnly(2008, 9, 1),
                IsCurrent = false,

                Summary =
                    "Provided senior-level technical support across computer systems, operating systems, business software, networking and peripherals while supporting end users and staff development.",

                DisplayOrder = 6,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Installed, configured and upgraded operating systems and standard business and administrative software.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Configured and assembled computers and peripherals including printers, scanners and related hardware.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Diagnosed and resolved software, hardware, email, network-connectivity and peripheral issues.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Provided technical support to end users and supported a centralised help desk for troubleshooting and technical advice.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Delivered staff training in basic computer operation and Microsoft Office applications including Word, Excel and PowerPoint.",
                DisplayOrder = 5
            },
            new()
            {
                Text = "Recommended hardware and software acquisitions based on application requirements and user needs.",
                DisplayOrder = 6
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = windowsServer },
            new() { Technology = activeDirectory },
            new() { Technology = networking }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Electric Power Corporation" &&
             x.Role == "Computer Technician",
        ct))
        {
            var windowsServer = await GetOrCreateTechnologyAsync(
                db, "Windows Server", "windows-server", ct);

            var networking = await GetOrCreateTechnologyAsync(
                db, "Networking", "networking", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Electric Power Corporation",
                Role = "Computer Technician",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2004, 8, 1),
                EndDate = new DateOnly(2006, 7, 1),
                IsCurrent = false,

                Summary =
                    "Provided computer hardware, software and network support while coordinating equipment procurement, maintenance and technical troubleshooting across the organisation.",

                DisplayOrder = 7,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Coordinated procurement of computer hardware, peripherals, consumables and related technology equipment.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Negotiated pricing for IT equipment with local and overseas suppliers and assessed opportunities to outsource computer services where appropriate.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Recommended hardware and software acquisitions based on analysis of user requirements and operational needs.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Led repair and maintenance of computers and other computer hardware and serviced peripheral equipment.",
                DisplayOrder = 4
            },
            new()
            {
                Text = "Diagnosed and resolved software, hardware, networking, email and peripheral-equipment issues.",
                DisplayOrder = 5
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = windowsServer },
            new() { Technology = networking }
                ]
            });
        }

        if (!await db.Experiences.AnyAsync(
        x => x.Company == "Electric Power Corporation" &&
             x.Role == "Technician",
        ct))
        {
            var scada = await GetOrCreateTechnologyAsync(
                db, "SCADA", "scada", ct);

            var radioCommunications = await GetOrCreateTechnologyAsync(
                db, "Radio Communications", "radio-communications", ct);

            db.Experiences.Add(new Experience
            {
                Company = "Electric Power Corporation",
                Role = "Technician",
                Location = "Apia, Samoa",
                StartDate = new DateOnly(2003, 9, 1),
                EndDate = new DateOnly(2004, 8, 1),
                IsCurrent = false,

                Summary =
                    "Supported telecommunications and operational technology used by the electricity utility, including radio communications and SCADA equipment supporting operational data transmission.",

                DisplayOrder = 8,
                IsPublished = true,

                Highlights =
                [
                    new()
            {
                Text = "Programmed handheld and mobile wireless radios used for the corporation's operational communications.",
                DisplayOrder = 1
            },
            new()
            {
                Text = "Diagnosed faults and performed maintenance and servicing of radio repeater receiver and transmitter equipment.",
                DisplayOrder = 2
            },
            new()
            {
                Text = "Commissioned and maintained Supervisory Control and Data Acquisition (SCADA) equipment to support reliable transmission of operational data to the Main Control Centre.",
                DisplayOrder = 3
            },
            new()
            {
                Text = "Assisted with servicing and maintenance activities involving hydro power generators.",
                DisplayOrder = 4
            }
                ],

                ExperienceTechnologies =
                [
                    new() { Technology = scada },
            new() { Technology = radioCommunications }
                ]
            });
        }

        await db.SaveChangesAsync(ct);
    }

    private static async Task<Technology> GetOrCreateTechnologyAsync(
      PortfolioDbContext db,
      string name,
      string slug,
      CancellationToken ct)
    {
        var trackedTechnology = db.Technologies.Local
            .FirstOrDefault(x => x.Slug == slug);

        if (trackedTechnology is not null)
        {
            return trackedTechnology;
        }

        var existingTechnology = await db.Technologies
            .FirstOrDefaultAsync(x => x.Slug == slug, ct);

        if (existingTechnology is not null)
        {
            return existingTechnology;
        }

        var technology = new Technology
        {
            Name = name,
            Slug = slug
        };

        db.Technologies.Add(technology);

        return technology;
    }
}