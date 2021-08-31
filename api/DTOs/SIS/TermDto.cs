using System;
using api.Models.SchoolManagement;

namespace api.DTOs.SIS
{
    public class TermDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Status Status { get; set; } = Status.Inactive;
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
        public string Year { get; set; }
    }
}