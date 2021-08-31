using System;
using System.Collections.Generic;
using api.Models.SchoolManagement;
using api.Models.UserManagment;

namespace api.Models.HumanResource
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public DateTime BirthDate { get; set; }
        public string Identity { get; set; }
        public DateTime ExpiredIdentity { get; set; }
        public string Passport { get; set; }
        public DateTime ExpiredPassport { get; set; }
        public string Email { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public Country EmployeeCountry { get; set; }
        public int EmployeeCountryId { get; set; }
        public Country BirthCountry { get; set; }
        public int BirthCountryId { get; set; }
        public Qualification Qualification { get; set; } = Qualification.Bachelor;
        public Job Job { get; set; }
        public int? JobId { get; set; } 
        public Specialty Specialty { get; set; }
        public int? SpecialtyId { get; set; }
        public DateTime JoinDate { get; set; } 
        public HRStatus Status { get; set; } = HRStatus.Inactive;
        public int YearsExperience { get; set; } = 0;
        public Section Section { get; set; }
        public int? SectionId { get; set; } = null;
        public User User { get; set; }
        public WorkSchedule Schedule { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        public ICollection<TimeOff> TimeOffs { get; set; }
        public ICollection<Request> Requests { get; set; }
        public ICollection<Reward> Rewards { get; set; }
        public ICollection<Deduction> Deductions { get; set; }
        public ICollection<Sanction> Sanctions { get; set; }
        public ICollection<Payroll> Payrolls { get; set; }
    }
}