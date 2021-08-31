using System.ComponentModel.DataAnnotations;

namespace api.DTOs.HMS
{
    public class AddJobDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string TitleAr { get; set; }
        [Required]
        public string Description { get; set; }
    }
}