using System;
using System.ComponentModel.DataAnnotations;
using api.Models.SchoolManagement;

namespace api.DTOs.SIS
{
    public class AddTermDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAr { get; set; }
        public Status Status { get; set; } = Status.Inactive;
        [Required]
        public DateTime Starting { get; set; }
        [Required]
        public DateTime End { get; set; }
        [Required]
        public int YearId { get; set; }
    }
}