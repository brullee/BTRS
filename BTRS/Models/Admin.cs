using System.ComponentModel.DataAnnotations;

namespace BTRS.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<BusTrip> trips { get; set; }
    }
}
