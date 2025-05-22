
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Part1update_cloud.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        // Foreign Key
        public int VenueId { get; set; }
       
    }

}
