using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models.HumanResource
{
    [Table("Documents")]
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
    }
    
}