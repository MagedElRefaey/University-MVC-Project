using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FirstTaskMVC.Models
{
    public class Department
    {
            public int DepartmentId { get; set; }

            [StringLength(10,MinimumLength=3)]
            public string DepartmentName { get; set; }

            [StringLength(50,MinimumLength=3)]
            public string DepartmentDescription { get; set; }
            
            public bool Active { get; set; }
            public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

            public virtual ICollection<Course> Courses { get; set; }

            public override string ToString()
            {
                return $"{DepartmentId}:{DepartmentName}:{DepartmentDescription}";
            }
        
    }
}
