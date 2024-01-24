using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TEG_api.Data;

namespace TEG_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckDbController : Controller
    {
        private readonly DbContextOptions<TEGContext> _db;

        public CheckDbController(DbContextOptions<TEGContext> db)
        {
            _db = db;
        }

        [HttpGet("checkDbStatus")]
        public bool DbStatus()
        {
            try
            {
                using (var context = new TEGContext(_db))
                {
                    context.Database.OpenConnection();
                    context.Database.CloseConnection();

                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
