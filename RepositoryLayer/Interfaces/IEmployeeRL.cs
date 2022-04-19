using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public interface IEmployeeRL
    {
        string AddEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        Employee GetEmployeeData(int? id);
        IEnumerable<Employee> GetAllEmployees();
        string DeleteEmployee(int? id);
    }
}  
