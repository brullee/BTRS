using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Bus_busTrips
    {
        [Key]
        public int id { get; set; }
        [Required]
        public Bus bus { get; set; }
        [Required]
        public BusTrip trip { get; set; }
    }
}
