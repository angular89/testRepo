using System.Collections.Generic;
using api.Models.SchoolManagement;

namespace api.Models.StudentInformation
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Grade Grade { get; set; }
        public int GradeId { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}