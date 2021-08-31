using System.Collections.Generic;
using api.Models.StudentInformation;

namespace api.Models.SchoolManagement
{
    public class OtherSchool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<School> Schools { get; set; }
    }
}