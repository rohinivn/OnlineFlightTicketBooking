using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace OnlineFlightTicketBooking.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "EmailId is required")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}