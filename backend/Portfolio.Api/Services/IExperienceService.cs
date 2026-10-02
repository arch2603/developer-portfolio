using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IExperienceService
{
    Task<IReadOnlyList<ExperienceDto>> GetAllAsync(CancellationToken ct);
}