using System.Collections.Generic;

namespace api.Models.HumanResource
{
    public class Specialty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}