using System;
using System.ComponentModel.DataAnnotations;

namespace Locations.Data
{
    public class OpeningHour
    {
        public int Id { get; set; }

        [Required]
        public virtual Location Location { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public int Opening { get; set; }

        [Required]
        public int Closing { get; set; }        
    }
}
