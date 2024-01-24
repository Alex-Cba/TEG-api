using Microsoft.AspNetCore.Mvc;

namespace TEG_api.Controllers.HealthyControllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        [HttpGet("checkStatus")]
        public IActionResult Status()
        {
            return Ok();
        }
    }
}
