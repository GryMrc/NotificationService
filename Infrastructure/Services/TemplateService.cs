using Application.ServiceContracts;
using System.Text;

namespace Infrastructure.Services;

public class TemplateService : ITemplateService
{
    public Task<string> RenderAsync(string templateBody, Dictionary<string, string> parameters)
    {
        var content = new StringBuilder(templateBody);

        foreach (var param in parameters)
        {
            content.Replace($"{{{{{param.Key}}}}}", param.Value);
        }

        return Task.FromResult(content.ToString());
    }
}
