using System.Collections.Generic;
using api.Models.UserManagment;

namespace api.Models.StudentInformation
{
    public class Guardian
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameAr { get; set; }
        public string Identity { get; set; }
        public Relation Relation { get; set; }
        public User User { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}