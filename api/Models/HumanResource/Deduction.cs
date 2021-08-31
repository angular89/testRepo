using System;

namespace api.Models.HumanResource
{
    public class Deduction
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DeductionType Type { get; set; }
        public TCalculate Calculate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}