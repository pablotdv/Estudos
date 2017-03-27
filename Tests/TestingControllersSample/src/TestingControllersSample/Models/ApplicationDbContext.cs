using Microsoft.EntityFrameworkCore;

namespace TestingControllersSample.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        public DbSet<StormSession> StormSessions { get; set; }
    }
}