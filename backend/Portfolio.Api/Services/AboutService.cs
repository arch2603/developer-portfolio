using Microsoft.EntityFrameworkCore;
using Portfolio.Api.Data;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public sealed class AboutService(PortfolioDbContext db) : IAboutService
{
    public Task<AboutDto?> GetAsync(CancellationToken ct) =>
        db.AboutProfiles
            .AsNoTracking()
            .Select(x => new AboutDto(
                x.Heading,
                x.Introduction,
                x.Biography,
                x.Location,
                x.Availability,
                x.Capabilities
                    .OrderBy(c => c.DisplayOrder)
                    .Select(c => c.Name)
                    .ToList()))
            .SingleOrDefaultAsync(ct);
}