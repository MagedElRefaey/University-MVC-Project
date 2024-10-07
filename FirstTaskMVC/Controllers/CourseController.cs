using FirstTaskMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;


namespace FirstTaskMVC.Controllers
{
    public class CourseController : Controller
    {
        UniversityMVC Database = new UniversityMVC();
        public IActionResult Index()
        {
            
            List<Course> model = Database.Courses.Include(d=>d.Departments).ToList();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Course course)
        {
            if(ModelState.IsValid)
            {
                Database.Courses.Add(course);
                Database.SaveChanges();
                return Redirect("/Course/Index");
            }
            return View(course);

        }
    }
}
