using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.Common.Request;
using TEG_api.CQRS.Commands.Create.Continent;



namespace TEG_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContinentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContinentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("CreateContinent")]
        public async Task<IActionResult> CreateContinent([FromBody] CreateContinentRequest request)
        {
            var response = await _mediator.Send(new CreateContinentCommand(request));

            return Ok(response);
        }
    }
}
