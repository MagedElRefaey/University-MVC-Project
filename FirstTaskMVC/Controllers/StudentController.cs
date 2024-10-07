using FirstTaskMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using FirstTaskMVC.Services;
using Microsoft.AspNetCore.Authorization;
namespace FirstTaskMVC.Controllers
{
    [Authorize]
    public class StudentController : Controller
    {

        UniversityMVC Database = new UniversityMVC();

        StudentServices studentServices = new StudentServices();
        //DepartmentService departmentService = new DepartmentService();
        NewDepartmentService departmentService;

        public StudentController(NewDepartmentService departmentservices)
        {
            departmentService = departmentservices;
        }

        public IActionResult Index()
        {
            List<Student> model = Database.Students.Include(d=>d.Department).ToList();
            return View(model);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            
            
           Student model = Database.Students.Include(d=>d.Department).FirstOrDefault(d=>d.StudentId==id);
               if(model == null)
               {
                   return NotFound();
               }
               return View(model);

        }


        public IActionResult ShowStudentForm()
        {
            // var departments = Database.Departments.ToList();
            var departments = departmentService.GetDepartments();
            SelectList DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.DepartmentList = DepartmentList;
            return View();
        }

 

        public IActionResult Create(Student student)
        {
            //Student student = new Student()
            //{
            //    StudentFirstName = firstname,
            //    StudentLastName = lastname,
            //    StudentAge = age,
            //    DepartmentNo= departmentno

            //};

            if (!ModelState.IsValid) // ازاي شغال وانا عاملها !!!!!!!!
            {
                studentServices.AddStudent(student);
                return Redirect("/Student/Index");
            }
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values.SelectMany(s => s.Errors);
            //    foreach(var error in errors)
            //    {
            //        Console.WriteLine(error.ErrorMessage);
            //    }
            //    return View(student);
            //}
            //Database.Students.Add(student);
            //Database.SaveChanges();
            //return Redirect("/Student/Index");
            else
            {
                // var departments = Database.Departments.ToList();
                var departments = departmentService.GetDepartments();
                SelectList DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
                ViewBag.DepartmentList = DepartmentList;
                return Content("asdsd");
            }


        }

        public IActionResult ShowUpdateStudentForm(int Id)
        {
            if (Id == null)
            {
                return BadRequest("No Id Found");
            }
            //Student student=Database.Students.SingleOrDefault(d => d.StudentId == id);
            Student student = studentServices.GetOneStudent(Id);
            if (student == null)
            {
                return NotFound();
            }
            // var departments = Database.Departments.ToList();
            var departments = Database.Departments.ToList();
            SelectList DepartmentList = new SelectList(departments, "DepartmentId", "DepartmentName");
            ViewBag.DepartmentList = DepartmentList;
            return View(student);
        }
        public IActionResult Update(Student student)
        {
            if (student == null)
            {
                return NotFound();
            }
            //Student model = Database.Students.SingleOrDefault(d=>d.StudentId==student.StudentId);
            studentServices.UpdateStudent(student);
            //if (model == null)
            //{
            //    return NotFound();
            //}
                //model.StudentFirstName = student.StudentFirstName;
                //model.StudentLastName = student.StudentLastName;
                //model.StudentAge = student.StudentAge;
                //model.DepartmentNo = student.DepartmentNo;
                //Database.Students.Update(model);
                //Database.SaveChanges();
                return Redirect("/Student/Index");

        }
        public IActionResult Test()
        {
            return Content("Test action works!");
        }


        public IActionResult ShowAddStudentImage(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            Student student = studentServices.GetOneStudent(Id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }


        public async Task <IActionResult> AddPhoto(IFormFile StudentPhoto)
        {
            //StreamWriter writer = new StreamWriter($"~/wwwroot/Images/"{);
            if (StudentPhoto == null)
            {
                return BadRequest("no photo");
            }
            string filename = "7"+"."+StudentPhoto.FileName.Split('.').Last();

            string path = Path.Combine("wwwroot", "Images", filename);

            //using (FileStream writer = new FileStream($"wwwroot/Images/{filename}",FileMode.Create))
            using (FileStream writer = new FileStream(path, FileMode.Create))
            {
                await StudentPhoto.CopyToAsync(writer);
            }

            ViewBag.img = filename;
            return View("ShowPhoto");



        }

        public IActionResult ShowAddStudentGradesUsingDictionary(int Id)
        {
            if (Id == null)
            {
                return BadRequest("not found");
            }
            Student student = studentServices.GetOneStudent(Id);
            if (student == null)
            {
                return NotFound();
            }

           
            return View(student);
        }

        public IActionResult AddGradeDictionary(Dictionary<int, string> GradeDictionary,int Id)
        {
            //var Course = Database.Students.SingleOrDefault(d => d.StudentId == Id);
            int ID=GradeDictionary.Keys.FirstOrDefault();
            //string grade = GradeDictionary[ID];
            //foreach (var key in GradeDictionary)
            //{
            //    var Course = Database.StudentCourses.SingleOrDefault(d => d.StudentId == key.Key);
            //    if (Course != null)
            //    {

            //        Course.Degree = key.Value;
            //        Database.SaveChanges();
            //    }
            //}
            //Student student= Database.Students.SingleOrDefault(d=>d.StudentId == ID);
            if(GradeDictionary==null||!GradeDictionary.Any())
            {
                return BadRequest("No given Grade");
            }
            foreach(var i in GradeDictionary)
            {
                Console.WriteLine($"{i.Key}:{i.Value}");
            }
            if(!GradeDictionary.ContainsKey(Id))
            {
                return BadRequest("Cannot find Id");
            }
            string grade = GradeDictionary[Id];
            ViewBag.Grade = grade;
            return View("ShowDictionary");
        }

         public IActionResult Delete(int ?Id)
        {
            if (Id == null)
            {
                return BadRequest("No Id Found");
            }
            Student student = studentServices.GetOneStudent(Id.Value);
            //Database.Students.Remove(student);
            //Database.SaveChanges();
            studentServices.DeleteStudent(Id.Value);
            return Redirect("/Student/Index");
        }

        public IActionResult CheckEmailExist(string StudentEmail,string FirstName,string LastName,int Age)
        {
            var student = Database.Students.SingleOrDefault(d=>d.StudentEmail == StudentEmail);
            if(student == null)
            {
                return Json(true);
            }
            return Json($"Iam Sorry this email is not free to use, you can try {FirstName}{LastName}{Age}@Gmail.com");
        }


    }
}
