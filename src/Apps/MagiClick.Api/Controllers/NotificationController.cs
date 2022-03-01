using MagiClick.Application.Common.Models;
using MagiClick.Application.Dto;
using MagiClick.Application.Notification.Commands.Get;
using MagiClick.Application.Notification.Commands.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MagiClick.Api.Controllers
{
    /// <summary>
    /// Notification
    /// </summary>
    [Authorize]
    public class NotificationController : BaseApiController
    {

        /// <summary>
        /// Add notification to person
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<PersonNotificationDto>>> PostPersonNotifications(PostPersonNotificationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        /// <summary>
        /// Send notificaiton to person
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("SendMessage")]
        public async Task<ActionResult<ServiceResult<List<string>>>> SendMessage(GetPersonNotificationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

    }
}
