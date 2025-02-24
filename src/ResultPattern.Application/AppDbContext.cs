using Microsoft.EntityFrameworkCore;

namespace ResultPattern.Application
{
    internal sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
    }
}
