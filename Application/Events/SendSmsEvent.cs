namespace Application.Events;

public record SendSmsEvent(string PhoneNumber, string TemplateCode, Dictionary<string, string> Parameters);
