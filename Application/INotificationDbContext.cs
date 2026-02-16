using Microsoft.EntityFrameworkCore;

namespace Application;

public interface INotificationDbContext
{
    DbSet<Domain.Entities.Notification> Notifications { get; }
    DbSet<Domain.Entities.NotificationTemplate> NotificationTemplates { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
