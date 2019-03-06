using System.Collections.Generic;
using System.Linq;
using Locations.Data;
using Locations.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Locations.Services
{
    public class LocationService : ILocationService
    {
        private LocationsContext context;

        public LocationService(LocationsContext context)
        {
            this.context = context;
        }

        public void Add(Location location)
        {
            context.Add(location);
            context.SaveChanges();
        }

        public IEnumerable<Location> GetAll(LocationType locationType)
        {
            return this.context.Locations.Where(l => locationType == LocationType.None || l.Type == locationType);
        }

        public Location GetById(int id)
        {
            return this.context.Locations.Include(l => l.OpeningHours).FirstOrDefault(x => x.Id == id);
        }

        public void Update(Location location)
        {            
            context.SaveChanges();
        }
    }
}
