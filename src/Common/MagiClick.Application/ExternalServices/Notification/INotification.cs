using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagiClick.Application.ExternalServices.Notification
{
    public  interface INotification
    {
        public string Send( string personName);
    }
}
