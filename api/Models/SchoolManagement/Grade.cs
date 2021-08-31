using System.Collections.Generic;
using api.Models.StudentInformation;

namespace api.Models.SchoolManagement
{
    public class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}