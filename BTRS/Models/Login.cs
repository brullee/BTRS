using System.ComponentModel.DataAnnotations;
namespace BTRS.Models
{
    public class Login
    {

            [Required(ErrorMessage = "*")]
            public string username { set; get; }

            [Required(ErrorMessage = "*")]
            public string password { set; get; }
        
    }

}
