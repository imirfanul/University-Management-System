using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseGateway : BaseGateway
    {
        public int Save(Course course)
        {
            string query = "INSERT INTO Course VALUES(@code,@name,@credit,@descrition,@departmentId,@semesterId,@action)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@code", course.Code);
            Command.Parameters.AddWithValue("@name", course.Name);
            Command.Parameters.AddWithValue("@credit", course.Credit);
            Command.Parameters.AddWithValue("@descrition", course.Descrition);
            Command.Parameters.AddWithValue("@departmentId", course.DepartmentId);
            Command.Parameters.AddWithValue("@semesterId", course.SemesterId);
            Command.Parameters.AddWithValue("@action", 1);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(string name)
        {

            string query = "SELECT * FROM Course WHERE Name='" + name + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public bool IsCodeExsists(string code)
        {

            string query = "SELECT * FROM Course WHERE Code='" + code + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public List<Department> GetDepartments()
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

        public List<Course> GetCourses()
        {
            string query = "SELECT * FROM Course";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                course.Credit = float.Parse(Reader["Credit"].ToString());

                courses.Add(course);
            }
            Connection.Close();
            return courses;
        }

        public List<Course> GetCoursesById(int departmentId)
        {
            string query = "SELECT Id,Code,Name FROM Course WHERE DepartmentId=" + departmentId + " AND Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course=new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<Course> GetCoursesByRegId(int Id)
        {
            string query = "SELECT * FROM Course INNER JOIN Student ON Student.DepartmentId=Course.DepartmentId WHERE Student.Id="+Id+" AND Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Code = Reader["Code"].ToString();
                course.Name = Reader["Name"].ToString();
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
        //------------------Unassign Course----------------

        public List<Course> GetAllCourseByAction()
        {
            string query = "SELECT * FROM Course WHERE Action=1";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();
            while (Reader.Read())
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Action = 1;
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public int UpdateCourse(Course course)
        {
            string query = "UPDATE Course SET Action=0 WHERE Id="+course.Id+"";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool isActionExist()
        {
            string query = "SELECT * FROM Course WHERE Action=1";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
    }
}