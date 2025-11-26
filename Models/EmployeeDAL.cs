using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SteadtlerHR.Models
{
    public class EmployeeDAL
    {
       string connectionString = "Data Source=localhost,1433;Initial Catalog=EmployeeDB;User ID=sa;Password=DevOpsDB#Nov25;TrustServerCertificate=True;";

        public IEnumerable<Employee> GetAllEmployee()
        {
            List<Employee> employeeList = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployees", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    Employee employee = new Employee();
                    employee.ID = Convert.ToInt32(dr["EmployeeID"].ToString());
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.Email = dr["Email"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Manager = dr["Manager"].ToString();

                    employeeList.Add(employee);
                }
                connection.Close();
            }
            return employeeList;
        }
        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_InsertEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Manager", employee.Manager);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_UpdateEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                command.Parameters.AddWithValue("@EmployeeID", employee.ID);
                command.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Manager", employee.Manager);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
        }

        public void DeleteEmployee(int? employeeID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("SP_DeleteEmployee", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@EmployeeID", employeeID);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public Employee GetEmployeeByID(int? employeeID)
        {
            Employee employee = new Employee();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SP_GetEmployeesByID", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    employee.ID = Convert.ToInt32(dr["EmployeeID"].ToString());
                    employee.EmployeeName = dr["EmployeeName"].ToString();
                    employee.Email = dr["Email"].ToString();
                    employee.Department = dr["Department"].ToString();
                    employee.Manager = dr["Manager"].ToString();

                }
                connection.Close();
            }
            return employee;
        }
    }
}
