using System.ComponentModel.DataAnnotations;

namespace OnlineFlightTicketBooking.Entity
{
     public class FlightClassDetail
    {
        [Key]
        public int FlightClassDetailId { get; set; }
        public int FlightId { get; set; }
        public int FlightClassId { get; set; }
        [Required]
        public float Cost { get; set; }
        [Required]
        public int NoOfSeat { get; set; }

        //many flightclassdetail Id will have only one flight 
        public Flight Flight { get; set; }

        //many flightclassdetail Id will have only one flight class
        public FlightClass FlightClass { get; set; }

    }
}
