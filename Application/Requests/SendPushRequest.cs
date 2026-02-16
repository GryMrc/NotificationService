namespace Application.Requests;

public record SendPushRequest(string DeviceToken, string TemplateCode, Dictionary<string, string> Parameters);
