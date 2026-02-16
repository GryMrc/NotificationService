namespace Application.Events;

public record SendPushEvent(string DeviceToken, string TemplateCode, Dictionary<string, string> Parameters);
