using Microsoft.EntityFrameworkCore;

namespace Locations.Data
{
    public class LocationsContext : DbContext
    {
        public LocationsContext()
        {

        }

        public LocationsContext(DbContextOptions<LocationsContext> options) : base(options)
        {

        }
        
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<OpeningHour> OpeningHours { get; set; }
    }
}
