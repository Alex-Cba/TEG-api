using Microsoft.AspNetCore.Mvc;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MissionController : Controller
    {
        [HttpGet("checkStatus")]
        public IActionResult Status()
        {
            return Ok();
        }
    }
}
