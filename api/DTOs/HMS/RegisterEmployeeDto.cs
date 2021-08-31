using System;
using System.ComponentModel.DataAnnotations;
using api.Models.HumanResource;

namespace api.DTOs.HMS
{
    public class RegisterEmployeeDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string FullNameAr { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage ="Identity length should be 10 numbers")]
        [StringLength(10), MinLength(10)]
        public string Identity { get; set; }
        [Required]
        public DateTime ExpiredIdentity { get; set; }
        [Required]
        public string Passport { get; set; }
        [Required]
        public DateTime ExpiredPassport { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?!0+$)[0-9]{9,9}$", ErrorMessage ="Mobile format should be: 5xxxxxxxx")]
        public string Mobile1 { get; set; }
        [Required]
        [RegularExpression(@"^(?!0+$)[0-9]{9,9}$", ErrorMessage ="Mobile format should be: 5xxxxxxxx")]
        public string Mobile2 { get; set; }
        [Required]
        public int EmployeeCountryId { get; set; }
        [Required]
        public int BirthCountryId { get; set; }
        [Required]
        public Qualification Qualification { get; set; }
        [Required]
        public int SpecialtyId { get; set; }
        [Required]
        public int JobId { get; set; }
        [Required]
        public int YearsExperience { get; set; }
        /*
        [EqualTo("Password", ErrorMessage="Passwords do not match.")]
        public string RetypePassword { get; set; }
        */
    }
}