namespace FirstTaskMVC.Models
{
    public class User
    {
        public int? UserId { get; set; }

        public string? UserName { get; set; }

        public string? UserPassword { get; set; }

        public virtual ICollection<Role>? Role { get; set; } = new HashSet<Role>();
    }
}
