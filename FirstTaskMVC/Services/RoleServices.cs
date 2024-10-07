using FirstTaskMVC.Models;

namespace FirstTaskMVC.Services
{
    public class RoleServices
    {
        UniversityMVC Database = new UniversityMVC();

        public Role GetOneRole(int id)
        {
            return Database.Role.SingleOrDefault(d => d.RoleId == id);
        }

        public void AddRole(Role role)
        {
            Database.Role.Add(role);
            Database.SaveChanges();
        }

        public List<Role> GetAllRoles()
        {
            return Database.Role.ToList();
        }
    }
}
