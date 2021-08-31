using System.ComponentModel.DataAnnotations;

namespace api.DTOs.SIS
{
    public class AddGradeDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}