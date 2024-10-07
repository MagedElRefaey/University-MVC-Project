using FirstTaskMVC.Models;
using FirstTaskMVC.Services;
using FirstTaskMVC.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;
using System.Security.Claims;

namespace FirstTaskMVC.Controllers
{
    //[Authorize]
    public class AccountController : Controller
    {
        UniversityMVC Database = new UniversityMVC();
        UserServices Userservices = new UserServices();
        RoleServices RoleServices = new RoleServices();
        //UserServices Userservices;

        //public AccountController(UserServices userservices)
        //{
        //    Userservices = userservices;
        //}

        public IActionResult NewUserView()
        {
            //using (UniversityMVC Database = new UniversityMVC())
            //{
            //}
            var Users = Userservices.GetAllUsers();
            return View(Users);
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            Userservices.AddUser(user);
            return Redirect("/Account/NewUserView");
        }

        public IActionResult NewRoleView()
        {
            //using (UniversityMVC Database = new UniversityMVC())
            //{
            //}
            var Roles = RoleServices.GetAllRoles();
            return View(Roles);
        }
        public IActionResult RegisterRole()
        {
            //var Roles = RoleServices.GetAllRoles();
            return View();
        }

        [HttpPost]
        public IActionResult RegisterRole(Role role)
        {
            RoleServices.AddRole(role);
            return RedirectToAction("NewRoleView", "Account");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "Maged" && model.UserPassword == "123")
                {
                    Claim Name = new Claim(ClaimTypes.Name, model.UserName);
                    Claim Password = new Claim(ClaimTypes.Name, model.UserPassword);
                    Claim Email = new Claim(ClaimTypes.Email, $"{model.UserName}@Gmail.com");
                    Claim Role = new Claim(ClaimTypes.Role,"Admin");
                    
                    ClaimsIdentity Info = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                    Info.AddClaim(Name);
                    Info.AddClaim(Password);
                    Info.AddClaim(Email);
                    Info.AddClaim(Role);

                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(Info);
                    await HttpContext.SignInAsync(claimsPrincipal);
                    User user = new User()
                    {
                        UserName = model.UserName,
                        UserPassword = model.UserPassword,
                    };
                    Userservices.AddUser(model);
                    return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("", "incorrect");
                    return View(model);
                }
            }
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Home");
        }

        public IActionResult ShowAdminView(int id)
        {
            var model = RoleServices.GetAllRoles();
            return View(model);
        }

        
        public IActionResult ShowUserRoles(int id)
        {
            var model = Database.Role.Include(d => d.User).FirstOrDefault(d => d.RoleId == id);
            return View(model);
        }

        [Authorize(Roles="Admin")]
        public IActionResult ManageUsers(int id)
        {
            var Users = Database.User.ToList();
            //var CoursesList = departmentService.GetDepartments();
            //var CoursesInDepartment = Database.Departments.Include(d=>d.Courses).FirstOrDefault(d=>d.DepartmentId==id);
            var UsersinRole = Database.Role.Include(d => d.User).FirstOrDefault(d => d.RoleId == id);
            var UserNotInRole = Users.Except(UsersinRole.User);
            ViewBag.usersinrole = UsersinRole.User;
            ViewBag.usersnotinrole = UserNotInRole;
            return View();
        }

        [HttpPost]
        public IActionResult ManageUsers(int id, List<int> RemovedUsers, List<int> AddedUsers)
        {

            var UsersinRole = Database.Role.Include(d => d.User).FirstOrDefault(d => d.RoleId == id);
            foreach (var userid in RemovedUsers)
            {
                //var removedcourse = Database.Courses.FirstOrDefault(d => d.CourseID == courseID);
                var removedusers = Database.User.FirstOrDefault(d => d.UserId == userid);
                UsersinRole.User.Remove(removedusers);
            }

            foreach (var userid in AddedUsers)
            {
                //var addedcourse = Database.Courses.FirstOrDefault(d => d.CourseID == courseID);
                var addedusers = Database.User.FirstOrDefault(d => d.UserId == userid);
                UsersinRole.User.Add(addedusers);
            }
            Database.SaveChanges();
            return RedirectToAction("ShowAdminView", "Account");


            //public IActionResult AddUser(User user)
            //{
            //    Userservices.AddUser(user);
            //    return Redirect("/Student/Index");
        }
        }
}
