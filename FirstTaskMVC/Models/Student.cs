using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTaskMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [StringLength(50,MinimumLength=3)]
        public string StudentFirstName { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string StudentLastName { get; set; }

        [Range(18,35)]
        public int StudentAge { get; set; }

        

        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        [Remote("CheckEmailExist","Student",AdditionalFields= "StudentFirstName,StudentLastName,StudentAge")]
        public string StudentEmail { get; set; }

        public string StudentPassword { get; set; }

        [Compare("StudentPassword")]
        
        public string StudentConfirmPassword { get; set; }

        [ForeignKey("Department")]
        public int DepartmentNo { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<StudentCourses> Courses { get; set; }

        public override string ToString()
        {
            return $"{StudentId}:{StudentFirstName}:{StudentLastName}:{StudentAge}";
        }
    }
}
