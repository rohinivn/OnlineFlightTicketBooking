using System.ComponentModel.DataAnnotations;
namespace OnlineFlightTicketBooking.Models
{
    public class FlightClassDetailViewModel
    {
        [Key]
        public int FlightClassDetailId { get; set; }
        public int FlightClassId { get; set; }

        [Required(ErrorMessage = "Ticket Price is required")]
        [Range(0.01, 10000000.00, ErrorMessage = "Ticket Price must be between 0.01 and 10000000.00")]
        [DataType(DataType.Currency)]
        public float Cost { get; set; }

        [Required(ErrorMessage = "Ticket is required")]
        [Range(0, 700, ErrorMessage = "Tickets must be between 0 and 700")]
        public int NoOfSeat { get; set; }
        public int FlightId { get; set; }
    }
}