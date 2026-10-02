using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/experience")]
public sealed class ExperienceController(IExperienceService experienceService)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IReadOnlyList<ExperienceDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<ExperienceDto>>> Get(
        CancellationToken ct)
    {
        var experiences = await experienceService.GetAllAsync(ct);

        return Ok(experiences);
    }
}