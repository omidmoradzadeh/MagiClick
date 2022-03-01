using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MagiClick.Application.People.Commands.Get;
using MagiClick.Application.People.Commands.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MagiClick.Api.Controllers
{
    /// <summary>
    /// Person
    /// </summary>
    [Authorize]
    public class PersonController : BaseApiController
    {
        /// <summary>
        /// Insert Person
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<PersonDto>>> PostPerson(PostPersonQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Get all people
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<PersonDto>>>> GetPeople(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllPersonQuery(), cancellationToken));
        }
    }
}
