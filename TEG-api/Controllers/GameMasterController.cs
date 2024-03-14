using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.Common.Request;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameMasterController : Controller
    {
        private readonly IMediator _mediator;

        public GameMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Movs/Attack")]
        public async Task<IActionResult> Attack([FromBody] AttackRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
