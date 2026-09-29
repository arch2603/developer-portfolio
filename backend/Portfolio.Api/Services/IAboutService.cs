using Portfolio.Api.DTOs;

namespace Portfolio.Api.Services;

public interface IAboutService
{
    Task<AboutDto?> GetAsync(CancellationToken ct);
}