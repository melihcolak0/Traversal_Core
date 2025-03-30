using Microsoft.EntityFrameworkCore;

namespace SignalRAPIMSSQL.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
