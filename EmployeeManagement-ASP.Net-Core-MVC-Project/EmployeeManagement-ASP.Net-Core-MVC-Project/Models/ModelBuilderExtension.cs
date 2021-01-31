using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Vivek Arya",
                    Email = "one@one.org",
                    Department = Dept.IT

                },
                  new Employee
                {
                    Id = 2,
                    Name = "Vivek Sharma",
                    Email = "two@one.org",
                    Department = Dept.IT

                },
                new Employee
               {
                Id = 3,
                Name = "Vimal Mehta",
                Email = "three@one.org",
                Department = Dept.IT

                }

                );
        }
    }
}
