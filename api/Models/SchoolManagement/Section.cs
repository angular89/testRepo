using System.Collections.Generic;
using api.Models.HumanResource;

namespace api.Models.SchoolManagement
{
    public class Section
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public School School { get; set; }
        public int SchoolId { get; set; }
        public ICollection<Department> Departments { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}