using MicroServiceTransport.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceTransport.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Transport> Transports { get; set; }
    }
}
