using System.Collections.Generic;

namespace api.DTOs.SIS
{
    public class SchoolDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public ICollection<SectionDto> Sections { get; set; }
        public ICollection<YearDto> Years { get; set; }
    }
}