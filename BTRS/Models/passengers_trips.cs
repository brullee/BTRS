using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class passengers_trips
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Passenger passenger { get; set; }
        [Required]
        public BusTrip trip { get; set; }
    }
}
