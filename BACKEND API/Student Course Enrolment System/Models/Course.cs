using System.ComponentModel.DataAnnotations;

namespace Student_Course_Enrolment_System.Models
{
    public class Course
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? Description { get; set; }
    }
}
