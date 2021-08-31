using System.Collections.Generic;

namespace api.DTOs.SIS
{
    public class OtherSchoolDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        //public ICollection<StudentDto> Students { get; set; }
        public ICollection<SchoolDto> Schools { get; set; }
    }
}