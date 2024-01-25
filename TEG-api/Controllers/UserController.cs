using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.Services.Interface;

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

        [HttpGet("checkStatus")]
        public IActionResult Status()
        {
            return Ok();
        }

        [HttpGet("/GetAll")]
        public Task<IActionResult> GetAll()
        {

        }
    }
}
