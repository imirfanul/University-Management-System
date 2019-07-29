using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class EnrollGateway:BaseGateway
    {
        public List<EnrollViewModel> GetStudentNoByView(int registrationId)
        {
            //string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName," +
            //               "Course.Id,Course.Name AS CourseName FROM EnrollCourse INNER JOIN Student ON " +
            //               "EnrollCourse.RegistrationNo=Student.Id INNER JOIN Department ON " +
            //               "Student.DepartmentId=Department.Id INNER JOIN Course ON " +
            //               "EnrollCourse.CourseId=Course.Id WHERE EnrollCourse.RegistrationNo="+registrationId+"";

            string query = "SELECT dbo.Course.Id AS CourseId, dbo.Course.Name AS CourseName, dbo.Department.Name " +
                           "AS DepartmentName, dbo.Student.RegistrationNo, dbo.Student.DepartmentId, " +
                           "dbo.Student.Name AS StudentName, dbo.Student.Email FROM   dbo.Course INNER" +
                           " JOIN dbo.Department ON dbo.Course.DepartmentId = dbo.Department.Id INNER " +
                           "JOIN dbo.Student ON dbo.Department.Id = dbo.Student.DepartmentId WHERE " +
                           "Student.Id="+registrationId+"";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollViewModel> enrollViewModels=new List<EnrollViewModel>();
            while (Reader.Read())
            {
                EnrollViewModel viewModel=new EnrollViewModel();
                viewModel.Name = Reader["StudentName"].ToString();
                viewModel.Email = Reader["Email"].ToString();
                viewModel.Department = Reader["DepartmentName"].ToString();
                viewModel.CourseName = Reader["CourseName"].ToString();
                viewModel.CourseId = Convert.ToInt32(Reader["CourseId"]);
                enrollViewModels.Add(viewModel);
            }
            Reader.Close();
            Connection.Close();
            return enrollViewModels;
        }

        public List<EnrollViewModel> GetStudentNoByInfo(int registrationId)
        {
            //string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName," +
            //               "Course.Id,Course.Name AS CourseName FROM EnrollCourse INNER JOIN Student ON " +
            //               "EnrollCourse.RegistrationNo=Student.Id INNER JOIN Department ON " +
            //               "Student.DepartmentId=Department.Id INNER JOIN Course ON " +
            //               "EnrollCourse.CourseId=Course.Id WHERE EnrollCourse.RegistrationNo="+registrationId+"";

            string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName,Course.Id AS" +
                           " CourseId,Course.Name AS CourseName FROM EnrollCourse INNER JOIN Student ON " +
                           "EnrollCourse.RegistrationNo=Student.Id INNER JOIN Course ON " +
                           "EnrollCourse.CourseId=Course.Id INNER JOIN Department ON Course.DepartmentId=Department.Id WHERE EnrollCourse.RegistrationNo="+registrationId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<EnrollViewModel> enrollViewModels = new List<EnrollViewModel>();
            while (Reader.Read())
            {
                EnrollViewModel viewModel = new EnrollViewModel();
                viewModel.Name = Reader["StudentName"].ToString();
                viewModel.Email = Reader["Email"].ToString();
                viewModel.Department = Reader["DepartmentName"].ToString();
                viewModel.CourseName = Reader["CourseName"].ToString();
                viewModel.CourseId = Convert.ToInt32(Reader["CourseId"]);
                enrollViewModels.Add(viewModel);
            }
            Reader.Close();
            Connection.Close();
            return enrollViewModels;
        }
        public int Save(EnrollCourse enrollCourse)
        {
            string query = "INSERT INTO EnrollCourse VALUES(@registrationNo,@courseId,@date)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@registrationNo", enrollCourse.RegistrationNo);
            Command.Parameters.AddWithValue("@courseId", enrollCourse.CourseId);
            Command.Parameters.AddWithValue("@date", enrollCourse.Date.ToShortDateString());
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(EnrollCourse enrollCourse)
        {
            string query = "SELECT * FROM EnrollCourse WHERE CourseId=" + enrollCourse.CourseId + " AND RegistrationNo="+enrollCourse.RegistrationNo+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public List<Student> GetAllStudentRegNo()
        {
            string query = "SELECT EnrollCourse.RegistrationNo AS RegId,Student.RegistrationNo AS RegName FROM EnrollCourse INNER JOIN Student ON EnrollCourse.RegistrationNo=Student.Id GROUP BY EnrollCourse.RegistrationNo,Student.RegistrationNo";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student student = new Student();
                student.Id = Convert.ToInt32(Reader["RegId"]);
                student.RegistrationNo = Reader["RegName"].ToString();
                students.Add(student);
            }
            Reader.Close();
            Connection.Close();
            return students;
        }
    }
}