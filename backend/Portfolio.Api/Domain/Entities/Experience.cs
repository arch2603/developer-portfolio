namespace Portfolio.Api.Domain.Entities;

public sealed class Experience
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public required string Company { get; set; }
    public required string Role { get; set; }
    public required string Location { get; set; }

    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }

    public bool IsCurrent { get; set; }

    public required string Summary { get; set; }

    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }

    public ICollection<ExperienceHighlight> Highlights { get; set; } = [];
    public ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = [];
}