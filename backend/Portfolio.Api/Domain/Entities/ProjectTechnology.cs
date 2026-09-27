namespace Portfolio.Api.Domain.Entities;
public sealed class ProjectTechnology
{
    public Guid ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public int TechnologyId { get; set; }
    public Technology Technology { get; set; } = null!;
}