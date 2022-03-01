using MagiClick.Domain.Common;
using MagiClick.Domain.Entities;

namespace MagiClick.Domain.Event
{
    public class CityCreatedEvent : DomainEvent
    {
        public CityCreatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
