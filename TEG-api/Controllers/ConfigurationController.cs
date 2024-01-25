using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Querys.All.GetAllConfigurations;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigurationController : Controller
    {
        private readonly IMediator _mediator;

        public ConfigurationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllConfigurationsQuery()));
        }
    }
}
