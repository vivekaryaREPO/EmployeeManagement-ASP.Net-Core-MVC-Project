using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    //this interface makes the application more testable and maintainable and dependency injection is easy and effective
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllEmployees();

        Employee Delete(int id);

        Employee Add(Employee employee);

        Employee Update(Employee employee);
    }
}
