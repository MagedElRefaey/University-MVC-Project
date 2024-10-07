using FirstTaskMVC.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstTaskMVC.Services
{
    public class StudentServices
    {
        UniversityMVC Database = new UniversityMVC();

        public Student GetOneStudent(int id)
        {
            return Database.Students.SingleOrDefault(d => d.StudentId == id);
        }
        public List<Student> GetDepartments()
        {
            return Database.Students.ToList();
        }
        public List<Student> GetAllStudentsInDepartments()
        {
            return Database.Students.Include(x => x.Department).ToList();
        }
        //public Student GetAllStudentsInSpecificDepartments(int departmetnid)
        //{
        //    return Database.Departments.Include(d => d.Students).FirstOrDefault(d => d.DepartmentId == departmetnid);
        //}
        public void AddStudent(Student student)
        {
            Database.Students.Add(student);
            Database.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            Student student = Database.Students.FirstOrDefault(d => d.StudentId == id);
            Database.Students.Remove(student);
            Database.SaveChanges();
        }
        public void UpdateStudent(Student student)
        {
            Student model = Database.Students.SingleOrDefault(d => d.StudentId == student.StudentId);
            //if (model == null)
            //{
            //    return NotFound();
            //}
            model.StudentFirstName = student.StudentFirstName;
            model.StudentLastName = student.StudentLastName;
            model.StudentAge = student.StudentAge;
            model.StudentEmail = student.StudentEmail;
            model.DepartmentNo = student.DepartmentNo;
            
            Database.Students.Update(model);

            //Database.Students.Update(student);
            Database.SaveChanges();
        }

    }
}