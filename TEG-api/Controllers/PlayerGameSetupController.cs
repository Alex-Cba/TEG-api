using Microsoft.AspNetCore.Mvc;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayerGameSetupController : Controller
    {
        [HttpGet("checkStatus")]
        public IActionResult Status()
        {
            return Ok();
        }
    }
}
