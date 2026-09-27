using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;
public sealed class ProjectService(PortfolioDbContext db) : IProjectService
{
    public async Task<IReadOnlyList<ProjectSummaryDto>> GetPublishedAsync(CancellationToken ct) =>
        await db.Projects.AsNoTracking().Where(x => x.IsPublished)
            .OrderBy(x => x.DisplayOrder).ThenBy(x => x.Title)
            .Select(x => new ProjectSummaryDto(x.Slug, x.Title, x.Summary,
                x.IsFeatured, x.ProjectTechnologies.OrderBy(pt => pt.Technology.Name)
                    .Select(pt => pt.Technology.Name).ToList()))
            .ToListAsync(ct);

    public Task<ProjectDetailDto?> GetBySlugAsync(string slug, CancellationToken ct) =>
        db.Projects.AsNoTracking().Where(x => x.IsPublished && x.Slug == slug)
            .Select(x => new ProjectDetailDto(x.Slug, x.Title, x.Summary,
                x.IsFeatured, x.Description, x.RepositoryUrl, x.LiveUrl,
                x.ProjectTechnologies.OrderBy(pt => pt.Technology.Name)
                    .Select(pt => pt.Technology.Name).ToList()))
            .SingleOrDefaultAsync(ct);
}