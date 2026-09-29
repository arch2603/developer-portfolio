namespace Portfolio.Api.Domain.Entities;

public sealed class AboutProfile
{
    public Guid Id { get; set; }

    public string Heading { get; set; } = string.Empty;

    public string Introduction { get; set; } = string.Empty;

    public string Biography { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Availability { get; set; } = string.Empty;

    public DateTime UpdatedUtc { get; set; }

    public ICollection<AboutCapability> Capabilities { get; set; }
        = new List<AboutCapability>();
}