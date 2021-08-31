using System;
using api.Models;
using api.Models.HumanResource;

namespace api.DTOs.HMS
{
    public class UpdateEmployeeDto
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
        public int EmployeeCountryId { get; set; }
        public int BirthCountryId { get; set; }
        public Qualification Qualification { get; set; } 
        public int SpecialtyId { get; set; }
        public int JobId { get; set; }
        public DateTime JoinDate { get; set; } 
        public HRStatus Status { get; set; } 
        public int YearsExperience { get; set; } 
    }
}