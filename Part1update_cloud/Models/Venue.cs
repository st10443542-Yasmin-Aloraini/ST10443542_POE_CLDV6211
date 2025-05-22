using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Part1update_cloud.Models
{
    public class Venue
    {
        [Key] // Optional if convention handles it
        public int VenueId { get; set; } // Auto-increment by default for int

        [Required]
        public string VenueName { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public string ImageUrl { get; set; }
    }
}


