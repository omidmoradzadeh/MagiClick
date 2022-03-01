using MagiClick.Domain.Common;
using MagiClick.Domain.Entities;

namespace MagiClick.Domain.Event
{
    public class CityActivatedEvent : DomainEvent
    {
        public CityActivatedEvent(City city)
        {
            City = city;
        }

        public City City { get; }
    }
}
