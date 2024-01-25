using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.All.AllMatches;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatchController : Controller
    {
        private readonly IMediator _mediator;

        public MatchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllMatchesQuery()));
        }
    }
}
