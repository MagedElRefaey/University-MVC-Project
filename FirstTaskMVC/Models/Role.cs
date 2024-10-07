using System.ComponentModel.DataAnnotations.Schema;

namespace FirstTaskMVC.Models
{
    public class Role
    {
        public int ? RoleId { get; set; }

        public string ? RoleName { get; set; }

        //[ForeignKey("User")]
        //public int ? UserId { get; set; }

        public virtual ICollection <User> ?User { get; set;} = new HashSet<User>();
    }
}
