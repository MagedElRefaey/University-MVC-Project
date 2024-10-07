﻿// <auto-generated />
using System;
using FirstTaskMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstTaskMVC.Migrations
{
    [DbContext(typeof(UniversityMVC))]
    [Migration("20240822115316_TenthMigration")]
    partial class TenthMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.Property<int>("CoursesCourseID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentsDepartmentId")
                        .HasColumnType("int");

                    b.HasKey("CoursesCourseID", "DepartmentsDepartmentId");

                    b.HasIndex("DepartmentsDepartmentId");

                    b.ToTable("CourseDepartment");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseID"));

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("CourseID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("DepartmentDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Role", b =>
                {
                    b.Property<int?>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RoleId"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RoleId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<int>("DepartmentNo")
                        .HasColumnType("int");

                    b.Property<int>("StudentAge")
                        .HasColumnType("int");

                    b.Property<string>("StudentEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("StudentPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StudentId");

                    b.HasIndex("DepartmentNo");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.StudentCourses", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.User", b =>
                {
                    b.Property<int?>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UserId"));

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.Property<int>("RolesUserId")
                        .HasColumnType("int");

                    b.HasKey("RolesRoleId", "RolesUserId");

                    b.HasIndex("RolesUserId");

                    b.ToTable("RoleUser");
                });

            modelBuilder.Entity("CourseDepartment", b =>
                {
                    b.HasOne("FirstTaskMVC.Models.Course", null)
                        .WithMany()
                        .HasForeignKey("CoursesCourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstTaskMVC.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DepartmentsDepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Student", b =>
                {
                    b.HasOne("FirstTaskMVC.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.StudentCourses", b =>
                {
                    b.HasOne("FirstTaskMVC.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstTaskMVC.Models.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("RoleUser", b =>
                {
                    b.HasOne("FirstTaskMVC.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstTaskMVC.Models.User", null)
                        .WithMany()
                        .HasForeignKey("RolesUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Course", b =>
                {
                    b.Navigation("StudentCourses");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Department", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("FirstTaskMVC.Models.Student", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
