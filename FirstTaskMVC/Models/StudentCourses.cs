using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTaskMVC.Models
{
    public class StudentCourses
    {
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public string Degree { get; set; }

        public virtual Course Course { get; set; }

        public virtual Student Student { get; set; }
    }
}
