using System.Collections.Generic;
using X.PagedList;

namespace Locations.Models
{
    public class LocationsIndexViewModel
    {
        public IPagedList<LocationsDetailsViewModel> Locations { get; set; }        
        public string CurrentFilter { get; set; }
    }
}
