using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music_app.Application.Commands.Roles.AddRole;

namespace Music_app.Api.Controllers
{
    [ApiController]
    [Route("api/role")]
    public class RoleController : BaseController
    {
        public RoleController(IMediator mediator, IAuthorizationService authorizationService) : base(mediator, authorizationService)
        {
        }

        [HttpPost("create")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateRoleAsync([FromBody] AddRoleCommand command)
        {
            var resp = await _mediator.Send(command);
            return Ok(resp);
        }
    }
}