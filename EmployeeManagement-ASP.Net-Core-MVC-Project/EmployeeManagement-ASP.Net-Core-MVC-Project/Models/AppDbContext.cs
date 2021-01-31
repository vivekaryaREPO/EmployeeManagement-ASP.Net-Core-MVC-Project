using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    /*DbContext This is the class that we use in our application code to interact with 
       the underlying database.It is this class that manages the database connection 
      and is used to retrieve and save data in the database.

        To use the DbContext class in our application
        We create a class that derives from the DbContext class.
        DbContext class is in Microsoft.EntityFrameworkCore namespace.
    */
    public class AppDbContext : DbContext
    {
        /*
         For the DbContext class to be able to do any useful work, it needs an instance of the DbContextOptions class.
        The DbContextOptions instance carries configuration information such as the connection string, database provider to use etc.
        To pass the DbContextOptions instance we use the constructor as shown in the example below.
        We will discuss more about the DbContextOptions class in our next video when we discuss database connection string in ASP.NET Core.
         
         */
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            //base.OnModelCreating(modelBuilder);
        }
    }
}
