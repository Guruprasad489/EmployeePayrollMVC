using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IEmployeeBL
    {
        string AddEmployee(Employee employee);
        string UpdateEmployee(Employee employee);
        Employee GetEmployeeData(int? id);
        IEnumerable<Employee> GetAllEmployees();
        string DeleteEmployee(int? id);
    }
}
