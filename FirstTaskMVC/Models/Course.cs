using System.ComponentModel.DataAnnotations;

namespace FirstTaskMVC.Models
{
    public class Course
    {
        public int CourseID { get; set; }

        [StringLength(10, MinimumLength = 2)]
        public string CourseName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string CourseDescription { get; set; }
        public virtual ICollection<Department>? Departments { get; set; } = new HashSet<Department>();

        public virtual ICollection<StudentCourses>? StudentCourses { get; set; }

        public override string ToString()
        {
            return $"{CourseID}:{CourseName}:{CourseDescription}";
        }
    }
}
