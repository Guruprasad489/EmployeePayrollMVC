using CommonLayer.Models;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepositoryLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;

        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //To Add new employee record      
        public string AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpPayrollMVC"]))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Dept", employee.Dept);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.Startdate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return "Employee details added successfully";
                    }
                    else
                    {
                        return "Failed to add employee details";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //To Update the records of a particluar employee    
        public string UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpPayrollMVC"]))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", employee.EmpId);
                    cmd.Parameters.AddWithValue("@Name", employee.Name);
                    cmd.Parameters.AddWithValue("@ProfileImage", employee.ProfileImage);
                    cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                    cmd.Parameters.AddWithValue("@Dept", employee.Dept);
                    cmd.Parameters.AddWithValue("@Salary", employee.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employee.Startdate);
                    cmd.Parameters.AddWithValue("@Notes", employee.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();

                    if (result != 0)
                    {
                        return "Employee details updated successfully";
                    }
                    else
                    {
                        return "Failed to update employee details";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int? id)
        {
            try
            {
                Employee employee = new Employee();

                using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpPayrollMVC"]))
                {
                    string sqlQuery = "SELECT * FROM employee_payroll WHERE EmpId = " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            employee.EmpId = Convert.ToInt32(rdr["EmpID"] == DBNull.Value ? default : rdr["EmpID"]);
                            employee.Name = Convert.ToString(rdr["Name"] == DBNull.Value ? default : rdr["Name"]);
                            employee.ProfileImage = Convert.ToString(rdr["ProfileImage"] == DBNull.Value ? default : rdr["ProfileImage"]);
                            employee.Gender = Convert.ToChar(rdr["Gender"] == DBNull.Value ? default : rdr["Gender"]);
                            employee.Dept = Convert.ToString(rdr["Dept"] == DBNull.Value ? default : rdr["Dept"]);
                            employee.Salary = (float)(double)(rdr["Salary"] == DBNull.Value ? default : rdr["Salary"]);
                            employee.Startdate = Convert.ToDateTime(rdr["StartDate"] == DBNull.Value ? default : rdr["StartDate"]);
                            employee.Notes = Convert.ToString(rdr["Notes"] == DBNull.Value ? default : rdr["Notes"]);
                        }
                    }
                    else
                        return null;
                    con.Close();
                }
                return employee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        //To View all employees details      
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> empList = new List<Employee>();

                using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpPayrollMVC"]))
                {
                    string sqlQuery = "SELECT * FROM employee_payroll";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.CommandType = CommandType.Text;

                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            Employee employee = new Employee();

                            employee.EmpId = Convert.ToInt32(rdr["EmpID"] == DBNull.Value ? default : rdr["EmpID"]);
                            employee.Name = Convert.ToString(rdr["Name"] == DBNull.Value ? default : rdr["Name"]);
                            employee.ProfileImage = Convert.ToString(rdr["ProfileImage"] == DBNull.Value ? default : rdr["ProfileImage"]);
                            employee.Gender = Convert.ToChar(rdr["Gender"] == DBNull.Value ? default : rdr["Gender"]);
                            employee.Dept = Convert.ToString(rdr["Dept"] == DBNull.Value ? default : rdr["Dept"]);
                            employee.Salary = (float)(double)(rdr["Salary"] == DBNull.Value ? default : rdr["Salary"]);
                            employee.Startdate = Convert.ToDateTime(rdr["StartDate"] == DBNull.Value ? default : rdr["StartDate"]);
                            employee.Notes = Convert.ToString(rdr["Notes"] == DBNull.Value ? default : rdr["Notes"]);

                            empList.Add(employee);
                        }
                    }
                    else
                        return null;
                    con.Close();
                }
                return empList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //To Delete the record on a particular employee
        public string DeleteEmployee(int? id)
        {

            using (SqlConnection con = new SqlConnection(configuration["ConnectionString:EmpPayrollMVC"]))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@EmpId", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result != 0)
                    {
                        return "Employee details deleted successfully";
                    }
                    else
                    {
                        return "Failed to delete employee details";
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
