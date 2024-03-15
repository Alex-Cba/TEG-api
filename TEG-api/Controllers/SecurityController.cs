using MediatR;
using Microsoft.AspNetCore.Mvc;
using TEG_api.CQRS.Commands.Security.Jwt;
using TEG_api.Helpers.JwtSecurity;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly JwtHelper _jwtHelper;

        public SecurityController(IMediator mediator, JwtHelper jwtHelper)
        {
            _mediator = mediator;
            _jwtHelper = jwtHelper;
        }

        //TODO: Crear un login más seguro y robusto
        [HttpPost("LoginObsolete")]
        public async Task<IActionResult> LoginObsolete([FromBody] LoginObsolete request)
        {
            var result = _mediator.Send(new JwtSecurityCommand(request));

            if (!string.IsNullOrEmpty(result.Result))
            {
                return Ok(result.Result);
            }
            else
            {
                return BadRequest();
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> SessionToken()
        //{

        //}
    }

    public class LoginObsolete()
    {
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
    }
}
