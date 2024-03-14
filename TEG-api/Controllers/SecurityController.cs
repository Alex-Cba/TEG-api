using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TEG_api.Common.Models;
using TEG_api.Helpers.JwtSecurity;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : Controller
    {
        private readonly IMediator _mediator;
        private readonly string LoginName = "admin";
        private readonly string LoginPassword = "admin";
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
            if (LoginName.Equals(request.LoginName) && LoginPassword.Equals(request.LoginPassword))
            {
                var result = _jwtHelper.GenerateToken("1", request.LoginName, request.LoginPassword);
            
                return Ok(result);
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
