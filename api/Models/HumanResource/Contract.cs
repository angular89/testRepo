using System;

namespace api.Models.HumanResource
{
    public class Contract
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Issued { get; set; }
        public DateTime? Expired { get; set; }
        public ContractType Type { get; set; } = ContractType.FixedTerm;
        public string IBAN { get; set; }
        public int Basic { get; set; }
        public int Allownance { get; set; }
    }
}