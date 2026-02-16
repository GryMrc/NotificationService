using Application.ServiceContracts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class EmailService(ILogger<EmailService> logger) : IEmailService
{
    public Task<bool> SendAsync(string to, string subject, string body)
    {
        // Placeholder for SMTP or API integration (SendGrid, Mailkit, etc.)
        logger.LogInformation("Sending Email to {To}: {Subject} - {Body}", to, subject, body);
        return Task.FromResult(true);
    }
}
