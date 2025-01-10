using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Student_Course_Enrolment_System.Models
{
    public class Enrollment
    {
        public Enrollment()
        {
            EnrollmentDate = DateTime.Now;
        }

        [Key]
        [Required]
        public int Id { get; set; }
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public Student Student { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
    }
}
