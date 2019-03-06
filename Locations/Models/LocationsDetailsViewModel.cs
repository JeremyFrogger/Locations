using Locations.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Locations.Models
{
    public class LocationsDetailsViewModel
    {             
        public int Id { get; set; }

        [Required]        
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }
        public string County { get; set; }

        [DisplayName("Post Code")]
        [Required]
        public string PostCode { get; set; }              

        [Required]
        public string Phone { get; set; }

        [Required]
        [DisplayName("Store Type")]
        public int LocationTypeId { get; set; }
                
        public List<OpeningTimeViewModel> OpeningTimes { get; set; }

        public LocationTypeEx LocationType { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string GoogleMap
        {
            get
            {
                return $"https://maps.googleapis.com/maps/api/staticmap?center={this.Latitude},{this.Longitude}&zoom=14&size=300x300&key=AIzaSyDvy5PbhTa7CDF8WytP54gh8A7N5JwnIaA";
            }
        }

        
        public SelectList LocationTypes { get; set; }
        public List<SelectListItem> Opening { get; set; }
        public List<SelectListItem> Closing { get; set; }
    }
}
