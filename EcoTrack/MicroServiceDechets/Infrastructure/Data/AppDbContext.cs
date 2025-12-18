using MicroServiceDechets.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceDechets.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dechet> Dechets { get; set; }
    }
}
