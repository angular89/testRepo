using System;
using api.Models.SchoolManagement;
using api.Models.UserManagment;

namespace api.Models.StudentInformation
{
    public class Account
    {
        public int Id { get; set; }
        public Student Student { get; set; }
        public int StudentId { get; set; }
        public Year Year { get; set; }
        public int YearId { get; set; }
        public Grade Grade { get; set; }
        public int GradeId { get; set; }
        public Class Class { get; set; }
        public User OpenedBy { get; set; }
        public int OpenedById { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public StudentStatus Status { get; set; } = StudentStatus.Pending;
        

    }
}