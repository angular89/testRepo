using System;
using System.Collections.Generic;
using api.Models.SchoolManagement;

namespace api.DTOs.SIS
{
    public class YearDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public Status Status { get; set; } = Status.Inactive;
        public DateTime Starting { get; set; }
        public DateTime End { get; set; }
        public ICollection<SchoolDto> Schools { get; set; }
        public ICollection<TermDto> Terms { get; set; }
    }
}