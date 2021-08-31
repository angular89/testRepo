using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SIS
{
    public class AddOtherSchoolDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAr { get; set; }
    }
}