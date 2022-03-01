using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiClick.Application.Dto
{
    public class PersonNotificationDto
    {
        public string Name { get; set; }
        public string TCKN { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeName { get; set; }
    }
}
