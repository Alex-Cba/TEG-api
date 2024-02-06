using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.Mission.All;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : Controller
    {
        private readonly IMediator _mediator;

        public MissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllMissionsQuery()));
        }
    }
}
