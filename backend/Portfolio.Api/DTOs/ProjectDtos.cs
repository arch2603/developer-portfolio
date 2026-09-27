namespace Portfolio.Api.DTOs;
public sealed record ProjectSummaryDto(string Slug, string Title, string Summary,
    bool IsFeatured, IReadOnlyList<string> Technologies);
public sealed record ProjectDetailDto(string Slug, string Title, string Summary,
    bool IsFeatured, string Description, string? RepositoryUrl, string? LiveUrl,
    IReadOnlyList<string> Technologies);

