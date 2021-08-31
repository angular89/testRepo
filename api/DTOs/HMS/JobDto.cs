using System.Collections.Generic;

namespace api.DTOs.HMS
{
    public class JobDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string TitleAr { get; set; }
        public string Description { get; set; }
        public ICollection<EmployeeDto> Employees { get; set; }
    }
}