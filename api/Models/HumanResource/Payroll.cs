using System;

namespace api.Models.HumanResource
{
    public class Payroll
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
        public decimal Reward { get; set; } = 0;
        public decimal Deduction { get; set; } = 0;
        public decimal NetSalary { get; set; } = 0;
    }
}