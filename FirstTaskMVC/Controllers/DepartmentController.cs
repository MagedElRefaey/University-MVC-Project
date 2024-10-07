using FirstTaskMVC.Models;
using FirstTaskMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstTaskMVC.Services;
using Microsoft.AspNetCore.Authorization;
namespace FirstTaskMVC.Controllers
{
    public class DepartmentController : Controller
    {
        UniversityMVC Database = new UniversityMVC();
        StudentServices studentServices = new StudentServices();
        //DepartmentService departmentService = new DepartmentService();
        NewDepartmentService departmentService;
        CourseServices courseService = new CourseServices();

        public DepartmentController(NewDepartmentService departmentservice)
        {
            departmentService = departmentservice;
        }

        public IActionResult scopedfunction([FromServices] NewDepartmentService departmentservices)
        {
            string Service = $"{departmentService.GetHashCode()}:{departmentservices.GetHashCode()}";
            return Content(Service);
        }

        [Authorize]
        public IActionResult Index()
        {
            //List<Department> model = departmentService.GetnDepartments(); for only true state appears
            List<Department> model = departmentService.GetAllStudentsInDepartments();
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            //Department model = Database.Departments.Include(d => d.Students).FirstOrDefault(d => d.DepartmentId == id);
            Department model = departmentService.GetStudentInDepartment(id.Value);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);

        }

        public IActionResult ShowDepartmentForm()
        {
            return View();
        }

        public IActionResult Create(Department department)
        {
            //Student student = new Student()
            //{
            //    StudentFirstName = firstname,
            //    StudentLastName = lastname,
            //    StudentAge = age,
            //    DepartmentNo= departmentno

            //};

            if(!ModelState.IsValid)
            {
                //Database.Departments.Add(department);
                //Database.SaveChanges();
                departmentService.AddDepartment(department);
                return Redirect("/Department/Index");
            }
            return  View(department);
        }

        public IActionResult ShowCoursesDepartment(int id)
        {
            var model = departmentService.GetCourseInDepartment(id);
            return View(model);
        }
        public IActionResult ManageCourses(int id)
        {
            var CoursesList = Database.Courses.ToList();
            //var CoursesList = departmentService.GetDepartments();
            //var CoursesInDepartment = Database.Departments.Include(d=>d.Courses).FirstOrDefault(d=>d.DepartmentId==id);
            var CoursesInDepartment = departmentService.GetCourseInDepartment(id);
            var CoursesNotInDepartment = CoursesList.Except(CoursesInDepartment.Courses);
            ViewBag.coursesindepartment = CoursesInDepartment.Courses;
            ViewBag.coursesnotindepartment = CoursesNotInDepartment;
            return View();
        }

        [HttpPost]
        public IActionResult ManageCourses(int id, List<int>RemovedCourses , List<int>AddedCourses)
        {
            
            var CoursesInDepartment = departmentService.GetCourseInDepartment(id);
            foreach (var courseID in RemovedCourses)
            {
                //var removedcourse = Database.Courses.FirstOrDefault(d => d.CourseID == courseID);
                var removedcourse = courseService.GetCourse(courseID);
                CoursesInDepartment.Courses.Remove(removedcourse);
            }

            foreach (var courseID in AddedCourses)
            {
                //var addedcourse = Database.Courses.FirstOrDefault(d => d.CourseID == courseID);
                var addedcourse = courseService.GetCourse(courseID);
                CoursesInDepartment.Courses.Add(addedcourse);
            }
            Database.SaveChanges();
            return RedirectToAction("ShowCoursesDepartment", "Department", new {id=id});
        }
        public IActionResult AddDegree(int courseid, int departmetnid)
        {
            //var department = Database.Departments.Include(d => d.Students).FirstOrDefault(d => d.DepartmentId == departmetnid);
            var department = departmentService.GetStudentInDepartment(departmetnid);
            //var course = Database.Courses.FirstOrDefault(d => d.CourseID == courseid);
            var course = courseService.GetCourse(courseid);

            if (department == null || course == null)
            {
                return NotFound();
            }
            ShowViewModel model = new ShowViewModel
            {
                Departments = new List <Department> {department},
                Courses =  new List<Course> { course } 
            };
            return View (model);
            //List<Department>Department = new List<Department>Deparmtent() ;
        }
        [HttpPost]
        public IActionResult AddDegree(int departmentid, int courseid,Dictionary<int,string>StudentDegree)
        {
            foreach(var degree in StudentDegree)
            {
                var StudentCourse = Database.StudentCourses.FirstOrDefault(d => d.CourseId == courseid && d.StudentId == degree.Key);
                if (StudentCourse == null)
                {
                    Database.StudentCourses.Add(new StudentCourses() { CourseId = courseid, StudentId = degree.Key, Degree = degree.Value });
                }
                else
                {
                    StudentCourse.Degree=degree.Value;
                }
                
            }
            Database.SaveChanges ();
            return Redirect("/Department/Index");
        }
        public IActionResult DeleteDepartment(int? id)
        {
            departmentService.DeleteDepartment(id.Value);
            return Redirect("/Department/Index");
        }
    }
}
