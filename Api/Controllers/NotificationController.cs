using Application.Events;
using Application.Requests;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController(IPublishEndpoint publishEndpoint) : ControllerBase
{
    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailRequest request)
    {
        await publishEndpoint.Publish(new SendEmailEvent(request.To, request.TemplateCode, request.Parameters));
        return Ok(new { Message = "Email request queued." });
    }

    [HttpPost("send-sms")]
    public async Task<IActionResult> SendSms([FromBody] SendSmsRequest request)
    {
        await publishEndpoint.Publish(new SendSmsEvent(request.PhoneNumber, request.TemplateCode, request.Parameters));
        return Ok(new { Message = "Sms request queued." });
    }

    [HttpPost("send-push")]
    public async Task<IActionResult> SendPush([FromBody] SendPushRequest request)
    {
        await publishEndpoint.Publish(new SendPushEvent(request.DeviceToken, request.TemplateCode, request.Parameters));
        return Ok(new { Message = "Push notification request queued." });
    }
}
