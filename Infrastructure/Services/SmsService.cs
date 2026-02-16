using Application.ServiceContracts;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services;

public class SmsService(ILogger<SmsService> logger) : ISmsService
{
    public Task<bool> SendAsync(string phoneNumber, string message)
    {
        // Placeholder for SMS provider integration (Twilio, Netgsm, etc.)
        logger.LogInformation("Sending SMS to {PhoneNumber}: {Message}", phoneNumber, message);
        return Task.FromResult(true);
    }
}
