using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineFlightTicketBooking.Entity
{
    public class Account
    {
        [Key]
        public int Id { get; set; } 

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(50)]
        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(20)]
        [Column(TypeName = "varchar")]
        public string EmailId { get; set; }

        [Required]
        [MaxLength(10)]
        [Column(TypeName = "varchar")]
        public string Password { get; set; }

        [Required]
        [MaxLength(6)]
        [Column(TypeName = "varchar")]
        public string Gender { get; set; }

        [Required]
        public long PhoneNumber { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        [MaxLength(5)]
        [Column(TypeName = "varchar")]
        public string Role { set; get; }
    }
}
