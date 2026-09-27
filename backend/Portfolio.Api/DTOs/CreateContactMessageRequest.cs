using System.ComponentModel.DataAnnotations;
namespace Portfolio.Api.DTOs;
public sealed class CreateContactMessageRequest
{
    [Required, StringLength(120, MinimumLength = 2)] public string Name { get; init; } = "";
    [Required, EmailAddress, StringLength(254)] public string Email { get; init; } = "";
    [Required, StringLength(200, MinimumLength = 3)] public string Subject { get; init; } = "";
    [Required, StringLength(4000, MinimumLength = 10)] public string Message { get; init; } = "";
    [StringLength(200)] public string Website { get; init; } = ""; // honeypot
}