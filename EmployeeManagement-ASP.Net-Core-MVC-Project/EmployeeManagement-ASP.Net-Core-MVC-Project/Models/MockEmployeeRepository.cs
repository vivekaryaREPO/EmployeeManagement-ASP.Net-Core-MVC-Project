using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement_ASP.Net_Core_MVC_Project.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> employees;
        public MockEmployeeRepository()
        {
            this.employees = new List<Employee>() {
              new Employee(){Id=1,Name="Vivek",Email="vivek@vivek.com",Department=Dept.IT},
              new Employee(){Id=2,Name="Arya",Email="arya@vivek.com",Department=Dept.IT},
              new Employee(){Id=3,Name="Vinay",Email="vinay@vivek.com",Department=Dept.HR},
              new Employee(){Id=4,Name="Vimal",Email="vimal@vivek.com",Department=Dept.Sales},
              new Employee(){Id=5,Name="Vikrant",Email="vikrant@vivek.com",Department=Dept.Sales},

            };
        }

        Employee IEmployeeRepository.Add(Employee employee)
        {
            employee.Id = this.employees.Max(x => x.Id) + 1;
            this.employees.Add(employee);
            return employee;
        }

        Employee IEmployeeRepository.Delete(int id)
        {
            Employee emp = this.employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                this.employees.Remove(emp);
               
            }
            return emp;
        }

        IEnumerable<Employee> IEmployeeRepository.GetAllEmployees()
        {
            
            return this.employees;
        }

        Employee IEmployeeRepository.GetEmployee(int id)
        {
            return this.employees.FirstOrDefault(emp=>emp.Id==id);
        }

        Employee IEmployeeRepository.Update(Employee employee)
        {
            Employee emp = this.employees.FirstOrDefault(e=>e.Id==employee.Id);
            if(emp!=null)
            {
                emp.Name = employee.Name;
                emp.Email = employee.Email;
                emp.Department = employee.Department;
                return emp;
            }
            return employee;
        }
    }
}
