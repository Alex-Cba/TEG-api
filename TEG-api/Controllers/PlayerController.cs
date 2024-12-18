using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.Players.All;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private readonly IMediator _mediator;

        public PlayerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]

        //Summary
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllPlayersQuery()));
        }
    }
}
