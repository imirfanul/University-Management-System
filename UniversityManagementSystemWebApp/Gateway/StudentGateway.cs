using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentGateway : BaseGateway
    {
        public bool IsNameExsists(Student student)
        {

            string query = "SELECT * FROM Student WHERE Email='" + student.Email + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
        public List<Department> GetAllDepaertments()
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

        public int GetAllStudent(int departmentId)
        {
            string query = "SELECT * FROM Student WHERE DepartmentId="+departmentId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
         
            int count = 0;
            while (Reader.Read())
            {
                int newCount=count+1;
                count = newCount;

            }
            Connection.Close();
            return count;
        }

        //public int GetStudentCountByYearAndDepartment(int departmentId,int year)
        //{
        //    string query = "";
        //    Command = new SqlCommand(query, Connection);
        //    Connection.Open();
        //    int rowAffect = Command.ExecuteNonQuery();
        //    Connection.Close();
        //    return rowAffect;
        //}

        public StudentViewModel GetStudentInfoByRagNo(string RegistrationNo)
        {
            string query = "";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            StudentViewModel studentViewModel = null;
            if (Reader.Read())
            {
                studentViewModel=new StudentViewModel();
                studentViewModel.Id = Convert.ToInt32(Reader["Id"]);
                studentViewModel.RegistrationNo = Reader["RegistrationNo"].ToString();
                studentViewModel.Name = Reader["Name"].ToString();
                studentViewModel.Email = Reader["Email"].ToString();
                studentViewModel.Contact = Reader["Contact"].ToString();
                studentViewModel.RegisterDate = Convert.ToDateTime(Reader["RegisterDate"].ToString());
                studentViewModel.Address = Reader["Address"].ToString();
                studentViewModel.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                studentViewModel.DepartmentName = Reader["DepartmentName"].ToString();
                studentViewModel.DepartmentCode = Reader["DepartmentCode"].ToString();
            }
            Connection.Close();
            return studentViewModel;
        }

        public int Save(Student student)
        {
            string query = "INSERT INTO Student VALUES(@name,@email,@contact,@date,@address,@departmentId,@registrationNo)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@name", student.Name);
            Command.Parameters.AddWithValue("@email", student.Email);
            Command.Parameters.AddWithValue("@contact", student.Contact);
            Command.Parameters.AddWithValue("@date", student.RegisterDate);
            Command.Parameters.AddWithValue("@address", student.Address);
            Command.Parameters.AddWithValue("@departmentId", student.DepartmentId);
            Command.Parameters.AddWithValue("@registrationNo", student.RegistrationNo);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Student> GetAllStudentRegNo()
        {
            string query = "SELECT Id,RegistrationNo FROM Student";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students=new List<Student>();
            while (Reader.Read())
            {
                Student student=new Student();
                student.Id = Convert.ToInt32(Reader["Id"]);
                student.RegistrationNo = Reader["RegistrationNo"].ToString();
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }

        public List<StudentResultViewModel> GetRegNoByStudentInfo(int RegistrationNo)
        {
            string query = "SELECT Student.Id,Student.Name AS StudentName,Student.Email,Department.Id AS DepartmentId,Department.Name AS DepartmentName  FROM Student INNER JOIN Department ON Student.DepartmentId=Department.Id WHERE Student.Id=" + RegistrationNo + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentResultViewModel> studentResultViews = new List<StudentResultViewModel>();
            if (Reader.Read())
            {
                StudentResultViewModel studentResultView = new StudentResultViewModel();
                studentResultView.Id = Convert.ToInt32(Reader["Id"]);
                studentResultView.Name = Reader["StudentName"].ToString();
                studentResultView.Email = Reader["Email"].ToString();
                studentResultView.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                studentResultView.DepartmentName = Reader["DepartmentName"].ToString();
                studentResultViews.Add(studentResultView);
            }
            Connection.Close();
            return studentResultViews;
        }
    }

}