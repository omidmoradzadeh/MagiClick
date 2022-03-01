using System.Threading;
using System.Threading.Tasks;
using MagiClick.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MagiClick.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<NotificationType> NotificationTypes { get; set; }
        DbSet<PersonNotification> PersonNotifications { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
