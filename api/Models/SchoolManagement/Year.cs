using System;
using System.Collections.Generic;
using api.Models.StudentInformation;

namespace api.Models.SchoolManagement
{
    public class Year
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Status Status { get; set; } = Status.Inactive;
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
        public ICollection<School> Schools { get; set; }
        public ICollection<Term> Terms { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}