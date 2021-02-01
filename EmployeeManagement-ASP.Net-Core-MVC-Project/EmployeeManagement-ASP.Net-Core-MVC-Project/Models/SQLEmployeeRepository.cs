using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;
        private readonly ILogger<SQLEmployeeRepository> logger;

        public SQLEmployeeRepository(AppDbContext context,
            ILogger<SQLEmployeeRepository> _logger)
        {
            this.context = context;
            this.logger = _logger;
        }
        Employee IEmployeeRepository.Add(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        Employee IEmployeeRepository.Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if(employee!=null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            else
            {
                logger.LogInformation("Employee not found:");
            }
            return employee;
        }

        IEnumerable<Employee> IEmployeeRepository.GetAllEmployees()
        {
            return context.Employees;
        }

        Employee IEmployeeRepository.GetEmployee(int id)
        {
            return context.Employees.Find(id);
        }

        Employee IEmployeeRepository.Update(Employee employee)
        {
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employee;
        }
    }
}
