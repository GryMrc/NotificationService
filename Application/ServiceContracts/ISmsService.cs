namespace Application.ServiceContracts;

public interface ISmsService
{
    Task<bool> SendAsync(string phoneNumber, string message);
}
