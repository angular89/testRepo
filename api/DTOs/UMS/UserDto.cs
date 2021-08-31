using System;
using System.Collections.Generic;
using api.Models.HumanResource;
using api.Models.StudentInformation;
using api.Models.UserManagment;

namespace api.DTOs.UMS
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Mobile { get; set; }
        public DateTime RegisteringDate { get; set; } = DateTime.Now;
        public DateTime LastActive { get; set; } = DateTime.Now;
        public Actor Actor { get; set; }
        public UserStatus Status { get; set; } = UserStatus.Inactive;
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Guardian> Guardians { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}