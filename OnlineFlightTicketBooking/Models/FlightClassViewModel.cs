using System.ComponentModel.DataAnnotations;

namespace OnlineFlightTicketBooking.Models
{
    public class FlightClassViewModel
    {
        public int FlightClassId { get; set; }
        [Required]
        public string FlightClassName { get; set; }
        [Required]
        public string FlightClassDescription { get; set; }
    }
}