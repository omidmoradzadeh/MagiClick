using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MagiClick.Application.NotificationTypes.Commands.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MagiClick.Api.Controllers
{
    /// <summary>
    /// NotificationType
    /// </summary>
    [Authorize]
    public class NotificationTypeController : BaseApiController
    {
        /// <summary>
        /// Get all notification Types
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<NotificationTypeDto>>>> GetNotificationTypes(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetAllNotificationTypeQuery(), cancellationToken));
        }
    }
}
