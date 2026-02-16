namespace Application.Requests;

public record SendEmailRequest(string To, string TemplateCode, Dictionary<string, string> Parameters);
