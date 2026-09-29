using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;

[ApiController]
[Route("api/about")]
public sealed class AboutController(IAboutService about) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<AboutDto>> Get(CancellationToken ct)
    {
        var profile = await about.GetAsync(ct);

        return profile is null
            ? NotFound()
            : Ok(profile);
    }
}