namespace Portfolio.Api.DTOs;

public sealed record AboutDto(
    string Heading,
    string Introduction,
    string Biography,
    string Location,
    string Availability,
    IReadOnlyList<string> Capabilities
);