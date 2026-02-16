using Application;
using Application.Events;
using Application.ServiceContracts;
using Domain.Entities;
using Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Application.Consumers;

public class PushNotificationConsumer(
    IPushNotificationService pushService,
    ITemplateService templateService,
    INotificationDbContext dbContext) : IConsumer<SendPushEvent>
{
    public async Task Consume(ConsumeContext<SendPushEvent> context)
    {
        var @event = context.Message;
        
        var template = await dbContext.NotificationTemplates
            .FirstOrDefaultAsync(t => t.Code == @event.TemplateCode && t.Type == NotificationType.Push);

        if (template == null) return;

        var body = await templateService.RenderAsync(template.Body, @event.Parameters);
        var subject = template.Subject ?? "Push Notification";

        var success = await pushService.SendAsync(@event.DeviceToken, subject, body);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = @event.DeviceToken,
            Content = body,
            Subject = subject,
            Type = NotificationType.Push,
            Status = success ? NotificationStatus.Sent : NotificationStatus.Failed,
            SentAt = success ? DateTime.UtcNow : null
        };

        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync();
    }
}
