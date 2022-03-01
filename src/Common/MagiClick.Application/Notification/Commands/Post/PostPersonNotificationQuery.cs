using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.Common.Interfaces;
using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MapsterMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MagiClick.Application.Notification.Commands.Post
{
    public class PostPersonNotificationQuery : IRequestWrapper<PersonNotificationDto>
    {
        public int PersonId { get; set; }
        public int NotificationTypeId { get; set; }
    }

    public class PostPersonNotificationQueryHandler : IRequestHandlerWrapper<PostPersonNotificationQuery, PersonNotificationDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostPersonNotificationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PersonNotificationDto>> Handle(PostPersonNotificationQuery request, CancellationToken cancellationToken)
        {
            var person = await _context.People.SingleOrDefaultAsync(t => t.Id == request.PersonId);
            if(person == null)
                ServiceResult.Failed<PersonNotificationDto>(ServiceError.PersonNotExist);

            var notificationType = await _context.NotificationTypes.SingleOrDefaultAsync(t => t.Id == request.NotificationTypeId);
            if (person == null)
                ServiceResult.Failed<PersonNotificationDto>(ServiceError.NotificationTypeIdNotExist);

            var PersonNotifications = await _context.PersonNotifications.AddAsync(new Domain.Entities.PersonNotification() { NotificationTypeId = notificationType.Id , PersonId = person.Id });
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(new PersonNotificationDto() { Name= person.Name , NotificationType = notificationType.Name , TCKN = person.TCKN});
        }
    }
}
