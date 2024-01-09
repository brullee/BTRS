using Microsoft.EntityFrameworkCore;
using BTRS.Models;

namespace BTRS.Data
{
    public class SystemDbContext: DbContext
    {
        public SystemDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Passenger> passenger { set; get; }
        public DbSet<Admin> admin { set; get; }
        public DbSet<Bus> bus { set; get; }
        public DbSet<BusTrip> busTrip { set; get; }
        public DbSet<passengers_trips> passengers_trips { set; get; }

    }
}
