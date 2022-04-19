using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL employeeRL;
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            this.employeeRL = employeeRL;
        }

        public string AddEmployee(Employee employee)
        {
            try
            {
                return employeeRL.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateEmployee(Employee employee)
        {
            try
            {
                return employeeRL.UpdateEmployee(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Employee GetEmployeeData(int? id)
        {
            try
            {
                return employeeRL.GetEmployeeData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return employeeRL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DeleteEmployee(int? id)
        {
            try
            {
                return employeeRL.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
