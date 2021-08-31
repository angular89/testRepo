using System;
using System.Collections.Generic;
using api.Models.SchoolManagement;
using api.Models.UserManagment;

namespace api.Models.StudentInformation
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public Gender Gender { get; set; }
        public string BirthDate { get; set; }
        public Country StudentCountry { get; set; }
        public int StudentCountryId { get; set; }
        public Country PlaceCountry { get; set; }
        public int PlaceCountryId { get; set; }
        public DateTime RegisteringDate { get; set; } = DateTime.Now;
        public DateTime Admission { get; set; } = DateTime.Now;
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Identity { get; set; }
        public DateTime ExpiredIdentity { get; set; }
        public string Passport { get; set; }
        public DateTime ExpiredPassport { get; set; }
        public Religion Religion { get; set; } = Religion.Islam;
        public Guardian Guardian { get; set; }
        public int GuardianId { get; set; }
        public OtherSchool OtherSchool { get; set; }
        public User User { get; set; }
        public DateTime Update { get; set; } = DateTime.Now;
        public ICollection<Account> Accounts { get; set; }
    }
}