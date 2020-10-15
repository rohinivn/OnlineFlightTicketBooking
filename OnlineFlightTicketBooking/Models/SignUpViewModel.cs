using System.ComponentModel.DataAnnotations;

namespace OnlineFlightTicketBooking.Models
{
    public class SignUpViewModel
    {
        public int Id { set; get; }

        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Name Should not contain any special characters and Digit")]
        public string Name { get; set; }

        [Required(ErrorMessage = "EmailId is required")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please enter a valid email address")]
        public string EmailId { get; set; }

        [RegularExpression(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$", ErrorMessage = (@"At least one lower case letter,one upper case letter,one special character,one digits,At least 8 characters length"))]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password",ErrorMessage ="Retype the same password")]
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        [RegularExpression(@"^[789]+[0-9]{9}$",ErrorMessage ="Notvalid")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
    }
}