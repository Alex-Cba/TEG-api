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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllPlayersQuery()));
        }

        private string GetValue(string claim, string defaultValue = "") =>
           User.Claims
               .FirstOrDefault(x => x.Type.Equals(claim, StringComparison.OrdinalIgnoreCase))
               ?.Value ??
           defaultValue;
    }
}
