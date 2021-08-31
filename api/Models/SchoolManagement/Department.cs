using System.Collections.Generic;

namespace api.Models.SchoolManagement
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}