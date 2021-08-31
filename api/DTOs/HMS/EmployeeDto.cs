using System;
using System.Collections.Generic;
using api.Models.HumanResource;
using api.Models.UserManagment;

namespace api.DTOs.HMS
{
    public class EmployeeDto
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
        public string CountryName { get; set; }
        public string BirthPlace { get; set; }
        public Qualification Qualification { get; set; } 
        public string Specialty { get; set; }
        public DateTime JoinDate { get; set; } 
        public HRStatus Status { get; set; } 
        public int YearsExperience { get; set; }
        public string JobTitle { get; set; }
        public User user { get; set; }
        public ICollection<DocumentDto> Documents { get; set; }
    }
}