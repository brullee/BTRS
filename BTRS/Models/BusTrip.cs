using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTRS.Models
{
    public class BusTrip
    {

        [Key]
        public int TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey("AdminID")]
        public Admin admin { get; set; }
        public ICollection<passengers_trips> passengers_trips { get; set; }
        public ICollection<Bus_busTrips> bus_trips { get; set; }

    }
}
