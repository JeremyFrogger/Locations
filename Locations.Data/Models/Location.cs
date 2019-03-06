using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Locations.Data
{
    public class Location
    {
        public Location()
        {
            this.OpeningHours = new List<OpeningHour>();
        }

        public int Id { get; set; }
        
        [Required]        
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public LocationType Type { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [MaxLength(50)]
        public string County { get; set; }

        [Required]
        [MaxLength(10)]
        public string PostCode { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public double Latitude { get; set; }               
        
        public virtual IEnumerable<OpeningHour> OpeningHours { get; set; }
    }
}
