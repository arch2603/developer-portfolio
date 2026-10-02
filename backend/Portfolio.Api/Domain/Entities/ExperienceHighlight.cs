namespace Portfolio.Api.Domain.Entities;

public sealed class ExperienceHighlight
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid ExperienceId { get; set; }

    public Experience Experience { get; set; } = null!;

    public required string Text { get; set; }

    public int DisplayOrder { get; set; }
}