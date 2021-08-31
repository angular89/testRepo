using System.Collections.Generic;

namespace api.Models.HumanResource
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Description { get; set; }
        public ICollection<Specialty> Specialties { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}