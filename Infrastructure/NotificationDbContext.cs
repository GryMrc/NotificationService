using Application;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class NotificationDbContext(DbContextOptions<NotificationDbContext> options) : DbContext(options), INotificationDbContext
{
}
