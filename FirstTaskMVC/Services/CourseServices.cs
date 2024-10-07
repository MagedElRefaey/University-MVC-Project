using FirstTaskMVC.Models;

namespace FirstTaskMVC.Services
{
    public class CourseServices
    {
        UniversityMVC Database = new UniversityMVC();

        public List<Course> GetAllCourses(int id)
        {
            return Database.Courses.ToList();
        }
        public Course GetCourse(int id)
        {
            return Database.Courses.FirstOrDefault(d => d.CourseID == id);
        }
    }
}
