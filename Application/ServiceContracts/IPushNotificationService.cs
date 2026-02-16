namespace Application.ServiceContracts;

public interface IPushNotificationService
{
    Task<bool> SendAsync(string deviceToken, string title, string body);
}
