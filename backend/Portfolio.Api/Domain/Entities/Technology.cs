namespace Portfolio.Api.Domain.Entities;
public sealed class Technology
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Slug { get; set; }
    public ICollection<ProjectTechnology> ProjectTechnologies { get; set; } = [];
    public ICollection<ExperienceTechnology> ExperienceTechnologies { get; set; } = [];
}