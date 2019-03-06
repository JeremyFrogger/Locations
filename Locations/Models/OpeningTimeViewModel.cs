using System;
using System.ComponentModel.DataAnnotations;

namespace Locations.Models
{
    public class OpeningTimeViewModel
    {
        public int LocationId { get; set; }

        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [Required]
        public int Opening { get; set; }

        [Required]
        public int Closing { get; set; }

        public string OpenClosed
        {
            get
            {
                var open = this.Opening < 12 ? $"{this.Opening} am" : $"{this.Opening - 12} pm";
                var closed = this.Closing == 23 ? "midnight" : this.Closing < 12 ? $"{this.Closing} am" : $"{this.Closing - 12} pm";

                return $"{open} - {closed}";
            }
        }
    }
}
