using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Bus_busTrips
    {
        [Key]
        public int id { get; set; }
        public Bus bus { get; set; }
        public BusTrip trip { get; set; }
    }
}
