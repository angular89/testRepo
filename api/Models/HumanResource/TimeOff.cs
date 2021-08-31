using System;

namespace api.Models.HumanResource
{
    public class TimeOff
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public LeaveType Leave { get; set; }
        public bool Discount { get; set; }
        public bool Approve { get; set; }
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
    }
}