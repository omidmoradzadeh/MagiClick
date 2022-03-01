using System.Threading;
using System.Threading.Tasks;
using MagiClick.Application.ApplicationUser.Queries.GetToken;
using MagiClick.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace MagiClick.Api.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login and get JWT token email: admin@admin.com password: Admin_1988
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
