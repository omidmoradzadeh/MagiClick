using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiClick.Application.ExternalServices.Notification
{
    public class EmailGateway : INotification
    {
        public string Send(string personName)
        {
            return $"send Email to {personName} ";
        }
    }
}
