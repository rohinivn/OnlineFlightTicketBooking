using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFlightTicketBooking.Entity
{
    public class Flight
    {
        [Key]
        public int FlightId { set; get; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string FlightName { set; get; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string StartLocation { set; get; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string TargetLoation { set; get; }

        [Required]
        public DateTime DispatchDate { set; get; }

        [Required]
        public DateTime ArrivalDate { set; get; }
        
        //one flight will have many flightclassdetail Id
        public ICollection<FlightClassDetail> FlightClassDetails { get; set; }

        //one flight will have many flightclass Id
        public ICollection<FlightClass> FlightClass { get; set; }
    }
}
