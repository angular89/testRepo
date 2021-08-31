using System.Collections.Generic;

namespace api.Models.SchoolManagement
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public ICollection<Section> Sections { get; set; }
        public ICollection<Year> Years { get; set; }
        public OtherSchool OtherSchool { get; set; }
        public int OtherSchoolId { get; set; }
    }
}