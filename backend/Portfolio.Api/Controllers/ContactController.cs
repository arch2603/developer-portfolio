using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Portfolio.Api.Data;
using Portfolio.Api.Domain.Entities;
using Portfolio.Api.DTOs;

namespace Portfolio.Api.Controllers;
[ApiController, Route("api/contact")]
public sealed class ContactController(PortfolioDbContext db) : ControllerBase
{
    [HttpPost, EnableRateLimiting("contact")]
    public async Task<IActionResult> Create(CreateContactMessageRequest request, CancellationToken ct)
    {
        if (!string.IsNullOrWhiteSpace(request.Website)) return Accepted();
        db.ContactMessages.Add(new ContactMessage
        {
            Name = request.Name.Trim(),
            Email = request.Email.Trim().ToLowerInvariant(),
            Subject = request.Subject.Trim(),
            Message = request.Message.Trim()
        });
        await db.SaveChangesAsync(ct);
        return Accepted(new { message = "Thank you. Your message has been received." });
    }
}