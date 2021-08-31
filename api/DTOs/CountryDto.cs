using System.Collections.Generic;
using api.DTOs.HMS;
using api.DTOs.SMS;
using api.Models.HumanResource;
using api.Models.StudentInformation;

namespace api.DTOs
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Nationality { get; set; }
        public string NationalityAr { get; set; }
        public ICollection<Employee> EmployeeCountries { get; set; } 
        public ICollection<Employee> BirthCountries { get; set; } 
        public ICollection<Student> StudentCountries { get; set; } 
        public ICollection<Student> PlaceCountries { get; set; } 
    }
}