using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.Common.Interfaces;
using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MapsterMapper;
using System.Linq;
using System.Collections.Generic;
using MagiClick.Domain.Entities;

namespace MagiClick.Application.People.Commands.Get
{
    public class GetAllPersonQuery : IRequestWrapper<List<PersonDto>>
    {
    }

    public class GetAllPersonQueryHandler : IRequestHandlerWrapper<GetAllPersonQuery, List<PersonDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<PersonDto>>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var lstPeople = _context.People
                .Select(t => new PersonDto()
                {
                    Id = t.Id,
                    Name = t.Name,
                    TCKN = t.TCKN
                }).ToList();

            return ServiceResult.Success(lstPeople);
        }
    }
}
