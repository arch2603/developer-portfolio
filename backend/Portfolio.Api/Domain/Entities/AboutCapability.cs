namespace Portfolio.Api.Domain.Entities;

public sealed class AboutCapability
{
    public Guid Id { get; set; }

    public Guid AboutProfileId { get; set; }

    public string Name { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public AboutProfile AboutProfile { get; set; } = null!;
}