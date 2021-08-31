using System;
using System.Collections.Generic;

namespace api.Models.SchoolManagement
{
    public class Term
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Status Status { get; set; } = Status.Inactive;
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
        public Year Year { get; set; }
        public int YearId { get; set; }
    }
}