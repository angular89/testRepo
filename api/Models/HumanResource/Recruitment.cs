using System;
using api.Models.SchoolManagement;

namespace api.Models.HumanResource
{
    public class Recruitment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Job Job { get; set; }
        public int JobId { get; set; }
        public Specialty Specialty { get; set; }
        public int? SpecialtyId { get; set; }
        public string Description { get; set; }
        public string Exceperince { get; set; }
        public Section Section { get; set; }
        public int? SectionId { get; set; }
        public Department Department { get; set; }
        public int? DepartmentId { get; set; }
        public ContractType Conract { get; set; } 
        public Status Status { get; set; } = Status.Inactive;
        public int Number { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}