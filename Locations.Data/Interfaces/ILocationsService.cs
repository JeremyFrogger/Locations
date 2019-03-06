using System.Collections.Generic;

namespace Locations.Data.Interfaces
{
    public interface ILocationService
    {
        IEnumerable<Location> GetAll(LocationType locationType);
        Location GetById(int id);
        void Add(Location location);
        void Update(Location location);
    }
}
