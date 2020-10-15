using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineFlightTicketBooking.Models
{
    public class FlightViewModel
    {
        public int FlightId { get; set; }
        [Required(ErrorMessage = "Flight name is required.")]
        [RegularExpression(@"^(([a-zA-Z0-9]+[\s]{1}[a-zA-Z0-9]+)|([a-zA-Z0-9]+))$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        public string FlightName { set; get; }
        [Required(ErrorMessage = "Start Location is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Start Location Should not contain any special characters and Digit")]
        public string StartLocation { set; get; }
        [Required(ErrorMessage = "Target Location is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Target Location Should not contain any special characters and Digit")]
        public string TargetLoation { set; get; }
        [Required(ErrorMessage ="Dispatch Date is Required")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]\d{4}$", ErrorMessage = "Date should be in dd-mm-yyyy format")]
        public DateTime DispatchDate { set; get; }

        [Required(ErrorMessage = "Arrival Date is Required")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])[-](0[1-9]|1[012])[-]\d{4}$", ErrorMessage = "Date should be in dd-mm-yyyy format")]
        public DateTime ArrivalDate { set; get; }
    } 

}