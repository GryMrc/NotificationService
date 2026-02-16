using Application.Events;
using Application.ServiceContracts;
using Domain.Entities;
using Domain.Enums;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Application.Consumers;

public class EmailNotificationConsumer(
    IEmailService emailService,
    ITemplateService templateService,
    INotificationDbContext dbContext) : IConsumer<SendEmailEvent>
{
    public async Task Consume(ConsumeContext<SendEmailEvent> context)
    {
        var @event = context.Message;
        
        var template = await dbContext.NotificationTemplates
            .FirstOrDefaultAsync(t => t.Code == @event.TemplateCode && t.Type == NotificationType.Email);

        if (template == null) return;

        var body = await templateService.RenderAsync(template.Body, @event.Parameters);
        var subject = template.Subject ?? "Notification";

        var success = await emailService.SendAsync(@event.To, subject, body);

        var notification = new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = @event.To,
            Content = body,
            Subject = subject,
            Type = NotificationType.Email,
            Status = success ? NotificationStatus.Sent : NotificationStatus.Failed,
            SentAt = success ? DateTime.UtcNow : null
        };

        dbContext.Notifications.Add(notification);
        await dbContext.SaveChangesAsync();
    }
}
