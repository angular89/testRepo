using System;
using System.ComponentModel.DataAnnotations;
using api.Models.UserManagment;

namespace api.DTOs.UMS
{
    public class RegisterUserDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^(?!0+$)[0-9]{9,9}$", ErrorMessage ="Mobile format should be: 5xxxxxxxx")]
        public string Mobile { get; set; }
        public DateTime RegisteringDate { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        [Required]
        public Actor Actor { get; set; }
    }
}