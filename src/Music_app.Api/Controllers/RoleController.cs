using System.Net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Music_app.Application.Commands.Roles.Add;
using Music_app.Application.Commands.Roles.Delete;
using Music_app.Application.Commands.Roles.Update;
using Music_app.Application.Queries.Roles.GetAllRole;

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
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRoleAsync([FromBody] AddRoleCommand command)
        {
            var resp = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.Created, resp);
        }

        [HttpPatch("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRoleAsync([FromQuery] string id, [FromBody] UpdateRoleCommand command)
        {
            command.SetId(id);

            var resp = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, resp);
        }

        [HttpDelete("delete")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> UpdateRoleAsync([FromQuery] string id)
        {
            var command = new DeleteRoleCommand();
            command.SetId(id);
            var resp = await _mediator.Send(command);
            return StatusCode((int)HttpStatusCode.OK, resp);
        }

        [HttpGet("get-all")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllRoleAsync()
        {
            var resp = await _mediator.Send(new GetAllRoleQuery());
            return Ok(resp);
        }
    }
}