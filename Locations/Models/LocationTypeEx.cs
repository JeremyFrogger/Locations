using Locations.Data;
using System.Collections.Generic;

namespace Locations.Models
{
    public class LocationTypeEx
    {
        public static IEnumerable<LocationTypeEx> LocationTypes = new List<LocationTypeEx>
        {
            new LocationTypeEx(Data.LocationType.Local, "Local Shop", "badge badge-pill badge-info float-right"),
            new LocationTypeEx(Data.LocationType.Megastore, "Mega-Store", "badge badge-pill badge-danger float-right"),
            new LocationTypeEx(Data.LocationType.TownStore, "Town Store", "badge badge-pill badge-success float-right")
        };

        public LocationTypeEx(LocationType locationType, string description, string style)
        {
            this.LocationType = (int)locationType;
            this.Description = description;
            this.Style = style;
        }

        public int LocationType { get; }
        public string Description { get; }
        public string Style { get; }
    }
}
