namespace Application.Events;

public record SendEmailEvent(string To, string TemplateCode, Dictionary<string, string> Parameters);
