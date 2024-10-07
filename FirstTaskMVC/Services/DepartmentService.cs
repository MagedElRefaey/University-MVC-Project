using FirstTaskMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstTaskMVC.Services
{
    public class DepartmentService:NewDepartmentService
    {
        UniversityMVC Database = new UniversityMVC();

        public List<Department> GetDepartments()
        {
            return Database.Departments.Where(d=>d.Active == true).ToList();
        }
        public List<Department> GetAllStudentsInDepartments()
        {
            return Database.Departments.Include(x => x.Students).ToList();
        }
        public Department GetOneDepartment(int id)
        {
            return Database.Departments.FirstOrDefault(d => d.DepartmentId == id);
        }
        public Department GetStudentInDepartment(int id)
        {
            return Database.Departments.Include(d => d.Students).FirstOrDefault(d => d.DepartmentId == id); ;
        }
        public Department GetCourseInDepartment(int id)
        {
            return Database.Departments.Include(d => d.Courses).FirstOrDefault(d => d.DepartmentId == id);
        }
        public void AddDepartment(Department department)
        {
            Database.Departments.Add(department);
            Database.SaveChanges();
        }
        public void UpdateDepartment(Department department)
        {
            Database.Departments.Update(department);
            Database.SaveChanges();
        }
        public void DeleteDepartment(int id)
        {
            Department department = Database.Departments.SingleOrDefault(d => d.DepartmentId == id);
            department.Active = false;
            //Database.Departments.Remove(department);
            Database.SaveChanges();
        }
    }

    public class DepartmentServiceUpgrades() : NewDepartmentService
    {
        UniversityMVC Database = new UniversityMVC();
        List<Department> departments = [
            new Department (){DepartmentName = "SE",DepartmentDescription= "Software Engineering",Active=true},
            new Department (){DepartmentName = "BMD",DepartmentDescription= "Biomedical Informatics",Active=true},
            new Department (){DepartmentName = "BI",DepartmentDescription= "Bio Informatics",Active=true}
            ];

    //    List<Student> students = [
    //        new Student (){StudentFirstName = "SE",DepartmentDescription= "Software Engineering",Active=true},
    //        new Student (){DepartmentName = "BMD",DepartmentDescription= "Biomedical Informatics",Active=true},
    //        new Student (){DepartmentName = "BI",DepartmentDescription= "Bio Informatics",Active=true}
    //];

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(int id)
        {
            var dept = departments.FirstOrDefault(d => d.DepartmentId == id);
            departments.Remove(dept);
        }

        public List<Department> GetAllStudentsInDepartments()
        {
            //return Database.Departments.Include(x => x.Students).ToList();
            return departments;
        }

        public Department GetCourseInDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartments()
        {
            return departments;
        }

        public Department GetOneDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public Department GetStudentInDepartment(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
