using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class passengers_trips
    {
        [Key]
        public int Id { get; set; }
        public Passenger passenger { get; set; }
        public BusTrip trip { get; set; }
    }
}
