using Portfolio.Api.DTOs;
namespace Portfolio.Api.Services;
public interface IProjectService
{
    Task<IReadOnlyList<ProjectSummaryDto>> GetPublishedAsync(CancellationToken ct);
    Task<ProjectDetailDto?> GetBySlugAsync(string slug, CancellationToken ct);
}