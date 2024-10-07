using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

namespace FirstTaskMVC.Models
{
    public class UniversityMVC : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourses> StudentCourses { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-TK25I7N\\SERVER2;Database=UniversityMVC;Integrated Security=sspi;trustservercertificate=true;encrypt=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.HasKey(d => d.StudentId);
                s.Property(d => d.StudentFirstName).IsRequired().HasMaxLength(50);
                s.Property(d => d.StudentLastName).IsRequired().HasMaxLength(50);
                s.Property(d => d.StudentAge).IsRequired();
                s.Property(d => d.StudentEmail).IsRequired();
                s.Property(d => d.StudentPassword).IsRequired().HasMaxLength(50);
                s.Ignore(d => d.StudentConfirmPassword);


            });

            modelBuilder.Entity<Department>(s =>
            {
                s.HasKey(d => d.DepartmentId);
                s.Property(d => d.DepartmentName).IsRequired().HasMaxLength(10);
                s.Property(d => d.DepartmentDescription).IsRequired().HasMaxLength(50);
                s.Property(d => d.DepartmentName).IsRequired();
                s.Property(d => d.DepartmentDescription).IsRequired();
            }
            );


            modelBuilder.Entity<Course>(s =>
            {
                s.HasKey(d => d.CourseID);
                s.Property(d => d.CourseName).IsRequired().HasMaxLength(10);
                s.Property(d => d.CourseDescription).IsRequired().HasMaxLength(50);
                s.Property(d => d.CourseName).IsRequired();
                s.Property(d => d.CourseDescription).IsRequired();
            }
            );
            modelBuilder.Entity<StudentCourses>(s =>
            {
                s.HasKey(d => new { d.StudentId, d.CourseId });

            }
            );

            modelBuilder.Entity<User>(s =>
            {
                s.HasKey(d => d.UserId);
                s.Property(d => d.UserName).IsRequired().HasMaxLength(50);
                s.Property(d => d.UserPassword).IsRequired().HasMaxLength(50);
            });

            modelBuilder.Entity<Role>(s =>
            {
                s.HasKey(d => d.RoleId);
                s.Property(d => d.RoleName).IsRequired().HasMaxLength(20);
            });
        }
    }
}
