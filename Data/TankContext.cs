using Microsoft.EntityFrameworkCore;
using MyTank.Models;

namespace MyTank.Data
{
    public class TankContext : DbContext
    {

        public TankContext(DbContextOptions<TankContext> options)
            : base(options)
        {
        }

        public DbSet<Tank> Tanks => Set<Tank>();
    }
}

