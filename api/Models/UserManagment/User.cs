using System;
using System.Collections.Generic;
using api.Models.HumanResource;
using api.Models.StudentInformation;

namespace api.Models.UserManagment
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
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