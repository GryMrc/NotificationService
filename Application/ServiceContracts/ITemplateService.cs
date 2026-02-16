namespace Application.ServiceContracts;

public interface ITemplateService
{
    Task<string> RenderAsync(string templateBody, Dictionary<string, string> parameters);
}
