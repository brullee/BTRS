using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Passenger
    {
        [Key]
        public int PassengerId { get; set; }

        [Required(ErrorMessage ="*")]
        public string Name { get; set; }

        [Required(ErrorMessage = "*")]
        public string Username { get; set; }

        [Required(ErrorMessage = "*")]
        public string password { get; set; }

        [Required(ErrorMessage = "*")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string Gender { get; set; }
        public ICollection<passengers_trips> passengers_trips { get; set; }

    }
}
