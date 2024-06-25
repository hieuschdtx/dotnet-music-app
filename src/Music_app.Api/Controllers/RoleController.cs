using MediatR;
using Microsoft.AspNetCore.Mvc;
using Music_app.Application.Commands.Roles.AddRole;
using System.Net;

namespace Music_app.Api.Controllers;

[ApiController]
[Route("api/role")]
public class RoleController : BaseController
{
    public RoleController(IMediator mediator) : base(mediator)
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