using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SIS
{
    public class AddDepartmentDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int SectionId { get; set; }
    }
}