using Microsoft.EntityFrameworkCore;

namespace TEG_api.Data
{
    public class TEGContext : DbContext
    {
        public TEGContext(DbContextOptions<TEGContext> options) : base(options)
        {

        }
        //public DbSet<TablaDePrubaMigracion> TablaDePrubaMigracions { get; set; }
    }
}
