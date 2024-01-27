using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.All.AllUsers;

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
        public async Task<IActionResult> CreateUser([FromBody] PostEmpleadoCommand)
        {
            var response = await _mediator.Send(command);
        }
    }
}
