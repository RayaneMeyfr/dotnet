using MicroServiceEnergie.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceEnergie.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Energie> Energies { get; set; }
    }
}
