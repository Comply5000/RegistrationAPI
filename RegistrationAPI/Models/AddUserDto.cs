using System.ComponentModel.DataAnnotations;

namespace RegistrationAPI.Models
{
    public class AddUserDto
    { 
        [Required]
        [MaxLength(15)]
        public string Login { get; set; }
        
        [Required]
        [MaxLength(16)]
        public string Password { get; set; }
        
        [Required]
        [MaxLength(16)]
        public string ConfirmedPassword { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        public int Age { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Street { get; set; }
        
        public int HouseNumber { get; set; }
    }
}