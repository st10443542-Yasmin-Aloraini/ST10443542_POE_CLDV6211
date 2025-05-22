using Microsoft.Extensions.Logging;

namespace Part1update_cloud.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        // Foreign Keys
        public int EventId { get; set; }
        public int VenueId { get; set; }

       
    }

}
