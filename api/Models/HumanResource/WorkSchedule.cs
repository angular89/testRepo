using System;
using System.Collections.Generic;

namespace api.Models.HumanResource
{
    public class WorkSchedule
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public ICollection<Day> WorkDays { get; set; } 
        public int Hours { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
    }
}