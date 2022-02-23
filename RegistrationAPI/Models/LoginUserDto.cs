using System.ComponentModel.DataAnnotations;

namespace RegistrationAPI.Models
{
    public class LoginUserDto
    {
        [Required] 
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}