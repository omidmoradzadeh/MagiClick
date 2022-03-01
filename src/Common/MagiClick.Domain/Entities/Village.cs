using MagiClick.Domain.Common;

namespace MagiClick.Domain.Entities
{
    public class Village : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }

    }
}
