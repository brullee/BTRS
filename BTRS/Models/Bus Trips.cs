using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Bus_Trips
    {

        [Key]
        public int TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        
    }
}
