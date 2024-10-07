using FirstTaskMVC.Models;

namespace FirstTaskMVC.Services
{
    public class UserServices
    {
        UniversityMVC Database = new UniversityMVC();

        public User GetOneUser(int id)
        {
            return Database.User.SingleOrDefault(d => d.UserId == id);
        }

        public void AddUser(User user)
        {
            Database.Add(user);
            Database.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return Database.User.ToList();
        }

    }
}
