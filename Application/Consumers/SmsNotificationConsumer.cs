using Application;
using Application.Events;
using Application.ServiceContracts;
using Domain.Entities;
using Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Application.Consumers;

public class SmsNotificationConsumer(
    ISmsService smsService,
    ITemplateService templateService,
    INotificationDbContext dbContext) : IConsumer<SendSmsEvent>
{
    public async Task Consume(ConsumeContext<SendSmsEvent> context)
    {
        var @event = context.Message;
        
        var template = await dbContext.NotificationTemplates
            .FirstOrDefaultAsync(t => t.Code == @event.TemplateCode && t.Type == NotificationType.Sms);

        if (template == null) return;

        var body = await templateService.RenderAsync(template.Body, @event.Parameters);

        var success = await smsService.SendAsync(@event.PhoneNumber, body);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = @event.PhoneNumber,
            Content = body,
            Type = NotificationType.Sms,
            Status = success ? NotificationStatus.Sent : NotificationStatus.Failed,
            SentAt = success ? DateTime.UtcNow : null
        };

        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync();
    }
}
