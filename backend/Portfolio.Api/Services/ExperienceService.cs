using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public sealed class ExperienceService(PortfolioDbContext db) : IExperienceService
{
    public async Task<IReadOnlyList<ExperienceDto>> GetAllAsync(
        CancellationToken ct)
    {
        return await db.Experiences
            .AsNoTracking()
            .Where(x => x.IsPublished)
            .OrderBy(x => x.DisplayOrder)
            .Select(x => new ExperienceDto(
                x.Id,
                x.Company,
                x.Role,
                x.Location,
                x.StartDate,
                x.EndDate,
                x.IsCurrent,
                x.Summary,

                x.Highlights
                    .OrderBy(h => h.DisplayOrder)
                    .Select(h => h.Text)
                    .ToList(),

                x.ExperienceTechnologies
                    .OrderBy(et => et.Technology.Name)
                    .Select(et => et.Technology.Name)
                    .ToList()
            ))
            .ToListAsync(ct);
    }
}