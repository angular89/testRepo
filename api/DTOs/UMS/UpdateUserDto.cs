using System.ComponentModel.DataAnnotations;
using api.Models.UserManagment;

namespace api.DTOs.UMS
{
    public class UpdateUserDto
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^(?!0+$)[0-9]{9,9}$", ErrorMessage ="Mobile format should be: 5xxxxxxxx")]
        public string Mobile { get; set; }
        [Required]
        public Actor Actor { get; set; }
        [Required]
        public UserStatus Status { get; set; } 
    }
}