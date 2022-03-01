using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.Common.Interfaces;
using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MapsterMapper;
using System.Linq;
using System.Collections.Generic;
using MagiClick.Domain.Entities;

namespace MagiClick.Application.People.Commands.Post
{
    public class PostPersonQuery : IRequestWrapper<PersonDto>
    {
        public string Name { get; set; }
        public string TCKN { get; set; }
    }

    public class PostPersonQueryHandler : IRequestHandlerWrapper<PostPersonQuery, PersonDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PostPersonQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<PersonDto>> Handle(PostPersonQuery request, CancellationToken cancellationToken)
        {
            if(_context.People.Where(t=>t.TCKN==request.TCKN).Any())
            {
                ServiceResult.Failed<List<PersonDto>>(ServiceError.PersonAlreadyExist);
            }

            Person person = new Person()
            {
                Name = request.Name,
                TCKN = request.TCKN
            };
            var newPerson = await _context.People.AddAsync(person);
            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(new PersonDto { Id = newPerson.Entity.Id , Name =  person.Name , TCKN = person.TCKN});
        }
    }
}
