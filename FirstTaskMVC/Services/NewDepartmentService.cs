using FirstTaskMVC.Models;

namespace FirstTaskMVC.Services
{
    public interface NewDepartmentService
    {
        public List<Department> GetDepartments();
        public void AddDepartment(Department department);

        public void UpdateDepartment(Department department);

        public void DeleteDepartment(int id);

        public Department GetOneDepartment (int id);

        public List<Department> GetAllStudentsInDepartments();

        public Department GetStudentInDepartment(int id);

        public Department GetCourseInDepartment(int id);
    }
}
