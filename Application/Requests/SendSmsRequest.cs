namespace Application.Requests;

public record SendSmsRequest(string PhoneNumber, string TemplateCode, Dictionary<string, string> Parameters);
