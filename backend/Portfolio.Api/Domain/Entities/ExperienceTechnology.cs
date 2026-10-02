namespace Portfolio.Api.Domain.Entities;

public sealed class ExperienceTechnology
{
    public Guid ExperienceId { get; set; }

    public Experience Experience { get; set; } = null!;

    public int TechnologyId { get; set; }

    public Technology Technology { get; set; } = null!;
}