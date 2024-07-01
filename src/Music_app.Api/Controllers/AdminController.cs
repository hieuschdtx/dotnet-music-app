using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music_app.Application.Commands.Roles.Add;
using Music_app.Domain.Consts;

namespace Music_app.Api.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : BaseController
    {
        public AdminController(IMediator mediator, IAuthorizationService authorizationService) :
            base(mediator, authorizationService)
        {
        }

        // [HttpPost("create")]
        // [Authorize(policy: RoleConst.Manager)]
        // [ProducesResponseType((int)HttpStatusCode.Created)]
        // public async Task<IActionResult> CreateAdminAsync([FromBody] AddRoleCommand command)
        // {
        //     var resp = await _mediator.Send(command);
        //     return Ok(resp);
        // }

        // [HttpPost("login")]
        // [Authorize(policy: RoleConst.Manager)]
        // [ProducesResponseType((int)HttpStatusCode.OK)]
        // public async Task<IActionResult> LoginAdminAsync([FromBody] AddRoleCommand command)
        // {
        //     var resp = await _mediator.Send(command);
        //     return Ok(resp);
        // }
    }
}