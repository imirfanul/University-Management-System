using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DepartmentGateway : BaseGateway
    {
        public int Save(Department department)
        {
            string query = "INSERT INTO Department VALUES(@code,@name)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@code", department.Code);
            Command.Parameters.AddWithValue("@name", department.Name);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string name)
        {

            string query = "SELECT * FROM Department WHERE Name='"+name+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
        public bool IsCodeExsists(string code)
        {

            string query = "SELECT * FROM Department WHERE Code='" + code + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
        public Department GetDepartmentById(int departmentId)
        {
            string query = "SELECT * FROM Department WHERE Id = " + departmentId;
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Department department = null;
            if (Reader.HasRows)
            {
                department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return department;
        }
        public List<Department> GetAllDepartments()
        {

            string query = "SELECT * FROM Department";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Department> departmentList = new List<Department>();

            while (Reader.Read())
            {
                Department department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Code = Reader["Code"].ToString();
                department.Name = Reader["Name"].ToString();


                departmentList.Add(department);
            }
            Connection.Close();
            return departmentList;
        }

        public Department GetDepartmentNameById(string departmentName)
        {
            string query = "SELECT Id,Name FROM Department WHERE Name = " + departmentName;
            Command = new SqlCommand(query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Department department = null;
            if (Reader.HasRows)
            {
                department = new Department();
                department.Id = Convert.ToInt32(Reader["Id"]);
                department.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return department;
        }
       
    }
}