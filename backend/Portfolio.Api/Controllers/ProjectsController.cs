using Microsoft.AspNetCore.Mvc;
using Portfolio.Api.DTOs;
using Portfolio.Api.Services;

namespace Portfolio.Api.Controllers;
[ApiController, Route("api/projects")]
public sealed class ProjectsController(IProjectService projects) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<ProjectSummaryDto>>> GetAll(CancellationToken ct) =>
        Ok(await projects.GetPublishedAsync(ct));

    [HttpGet("{slug}")]
    public async Task<ActionResult<ProjectDetailDto>> GetBySlug(string slug, CancellationToken ct)
    {
        var project = await projects.GetBySlugAsync(slug, ct);
        return project is null ? NotFound() : Ok(project);
    }
}