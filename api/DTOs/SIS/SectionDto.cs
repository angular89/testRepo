using System.Collections.Generic;

namespace api.DTOs.SIS
{
    public class SectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public ICollection<DepartmentDto> Department { get; set; }
    }
}