using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFlightTicketBooking.Entity
{
    public class FlightClass
    {
        [Key]
        public int FlightClassId { get; set; }
        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string FlightClassName { get; set; }
        [Required]
        public string FlightClassDescription { get; set; }

        //one flight class will have many flightclassdetail Id
        public ICollection<FlightClassDetail> FlightClassDetail { get; set; }
    }
}
