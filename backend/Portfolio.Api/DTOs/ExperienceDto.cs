namespace Portfolio.Api.DTOs;

public sealed record ExperienceDto(
    Guid Id,
    string Company,
    string Role,
    string Location,
    DateOnly StartDate,
    DateOnly? EndDate,
    bool IsCurrent,
    string Summary,
    IReadOnlyList<string> Highlights,
    IReadOnlyList<string> Technologies
);