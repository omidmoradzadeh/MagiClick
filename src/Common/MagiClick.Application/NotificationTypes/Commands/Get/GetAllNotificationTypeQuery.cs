using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.Common.Interfaces;
using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MapsterMapper;
using System.Linq;
using System.Collections.Generic;

namespace MagiClick.Application.NotificationTypes.Commands.Get
{
    public class GetAllNotificationTypeQuery : IRequestWrapper<List<NotificationTypeDto>>
    {
    }

    public class GetAllNotificationTypeQueryHandler : IRequestHandlerWrapper<GetAllNotificationTypeQuery, List<NotificationTypeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllNotificationTypeQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<NotificationTypeDto>>> Handle(GetAllNotificationTypeQuery request, CancellationToken cancellationToken)
        {
            var lstNotificationType =  _context.NotificationTypes
                .Select(t => new NotificationTypeDto()
                {
                    Id = t.Id,
                    Name = t.Name
                }).ToList();

            return ServiceResult.Success(lstNotificationType);
        }
    }
}
