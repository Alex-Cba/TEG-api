using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.Common.Request;
using TEG_api.CQRS.Commands.User.Create;
using TEG_api.CQRS.Commands.User.SoftDelete;
using TEG_api.CQRS.Commands.User.Update;
using TEG_api.CQRS.Commands.User.Delete;
using TEG_api.CQRS.Querys.User.All;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            var response = await _mediator.Send(new CreateUserCommand(request));

            return Ok(response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var response = await _mediator.Send(new UpdateUserCommand(request));

            return Ok(response);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteUser([FromBody] Guid Id)
        {
            var response = await _mediator.Send(new DeleteUserCommand(Id));

            return Ok(response);
        }

        [HttpDelete("SoftDelete")]
        public async Task<IActionResult> SoftDeleteUser([FromBody] Guid Id)
        {
            var response = await _mediator.Send(new SoftDeleteUserCommand(Id));

            return Ok(response);
        }
    }
}
