namespace Application.ServiceContracts;

public interface IEmailService
{
    Task<bool> SendAsync(string to, string subject, string body);
}
