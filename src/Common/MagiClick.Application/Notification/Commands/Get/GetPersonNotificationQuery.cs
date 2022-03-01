using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.Common.Interfaces;
using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MapsterMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System;
using MagiClick.Application.ExternalServices.Notification;

namespace MagiClick.Application.Notification.Commands.Get
{

    public class GetPersonNotificationQuery : IRequestWrapper<List<string>>
    {
        public string TCKN { get; set; }
    }

    public class GetPersonNotificationHandler : IRequestHandlerWrapper<GetPersonNotificationQuery, List<string>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPersonNotificationHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<string>>> Handle(GetPersonNotificationQuery request, CancellationToken cancellationToken)
        {
            List<string> response = new List<string>();
            var person = await _context.People.SingleOrDefaultAsync(t => t.TCKN == request.TCKN);
            if(person == null)
                ServiceResult.Failed<PersonNotificationDto>(ServiceError.PersonNotExist);

            var personNotifications = (from per in _context.People
                                      join perNoti in _context.PersonNotifications on per.Id equals perNoti.PersonId
                                      join notiTy in _context.NotificationTypes on perNoti.NotificationTypeId equals notiTy.Id
                                      where per.TCKN == request.TCKN
                                      select new PersonNotificationDto() { TCKN = per.TCKN, Name = per.Name, NotificationType = notiTy.Name  , NotificationTypeName  = notiTy.TypeName}).ToList();

            foreach (var item in personNotifications)
            {
                var type = Type.GetType(string.Format("{0}.{1}", "MagiClick.Application.ExternalServices.Notification", item.NotificationTypeName));
                INotification instantiatedTypes =(INotification)Activator.CreateInstance(type);
                response.Add(instantiatedTypes.Send(item.Name));
            }

            return ServiceResult.Success(response);
        }
    }
}
