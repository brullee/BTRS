using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class BusTrip
    {

        [Key]
        public int TripId { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [ForeignKey("AdminID")]
        public Admin admin { get; set; }
        public ICollection<passengers_trips> passengers_trips { get; set; }
        public Bus bus { get; set; }

    }
}
