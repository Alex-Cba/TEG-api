using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.Maps.All;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MapController : Controller
    {
        private readonly IMediator _mediator;

        public MapController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllMapsQuery()));
        }
    }
}
