using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed depts table
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 1, DepartmentName = "ICT"});
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 2, DepartmentName = "HR" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 3, DepartmentName = "Payroll" });
            modelBuilder.Entity<Department>().HasData(
                new Department { DepartmentId = 4, DepartmentName = "Admins" });

            //see employee table
            modelBuilder.Entity<Employee>().HasData(
                new Employee {
                    EmployeeId = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "JohnDoe@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/John.jpg"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sam",
                    LastName = "Smit",
                    Email = "SamSmit@gmail.com",
                    DateOfBirth = new DateTime(1990, 11, 12),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/Sam.jpg"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Ian",
                    LastName = "Hook",
                    Email = "IanHook@gmail.com",
                    DateOfBirth = new DateTime(1956, 09, 23),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/Ian.png"
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Mecheal",
                    LastName = "Yoe",
                    Email = "MechealYoe@gmail.com",
                    DateOfBirth = new DateTime(1970, 12, 26),
                    Gender = Gender.Female,
                    DepartmentId = 3,
                    PhotoPath = "images/Mecheal.png"
                });
        }
    }
}
