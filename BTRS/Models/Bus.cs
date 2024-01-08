using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }
        public string CptName { get; set; }
        public int NOofSeats { get; set; }
        public ICollection<BusTrip> trips { get; set; }
    }
}