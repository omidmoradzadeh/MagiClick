using System.Threading.Tasks;
using MagiClick.Domain.Common;

namespace MagiClick.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
