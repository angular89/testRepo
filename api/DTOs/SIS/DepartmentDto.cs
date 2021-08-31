using System.Collections.Generic;

namespace api.DTOs.SIS
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public ICollection<GradeDto> Grades { get; set; }
    }
}