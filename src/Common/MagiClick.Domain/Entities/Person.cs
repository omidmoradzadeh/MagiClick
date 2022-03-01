using MagiClick.Domain.Common;

namespace MagiClick.Domain.Entities
{
    public class Person : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TCKN { get; set; }
    }
}
