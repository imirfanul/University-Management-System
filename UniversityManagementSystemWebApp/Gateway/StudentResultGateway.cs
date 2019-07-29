using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class StudentResultGateway : BaseGateway
    {
        public int Save(StudentResult studentResult)
        {
            string query = "INSERT INTO StudentResult VALUES(@registrationNo,@courseId,@gradeLetterId)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@registrationNo", studentResult.RegistrationNo);
            Command.Parameters.AddWithValue("@courseId", studentResult.CourseId);
            Command.Parameters.AddWithValue("@gradeLetterId", studentResult.GradeLetterId);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<StudentResultViewModel> GetRegNoByStudentResultInfo(int RegistrationNo)
        {
            string query = "SELECT Student.Name AS StudentName,Student.Email,Department.Name AS DepartmentName," +
                           "Course.Code,Course.Name AS CourseName,ISNULL(GradeLetter.GradeLetter,'Not Graded Yet') " +
                           "AS Grade FROM EnrollCourse INNER JOIN Student ON EnrollCourse.RegistrationNo=Student.Id " +
                           "INNER JOIN Course ON EnrollCourse.CourseId=Course.Id INNER JOIN Department" +
                           " ON Course.DepartmentId=Department.Id LEFT JOIN StudentResult ON " +
                           "EnrollCourse.CourseId=StudentResult.CourseId LEFT JOIN GradeLetter " +
                           "ON StudentResult.GradeLetterId=GradeLetter.Id WHERE EnrollCourse.RegistrationNo="+RegistrationNo+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<StudentResultViewModel> studentResultViews = new List<StudentResultViewModel>();
            while (Reader.Read())
            {
                StudentResultViewModel studentResultView = new StudentResultViewModel();
                studentResultView.Name = Reader["StudentName"].ToString();
                studentResultView.Email = Reader["Email"].ToString();
                studentResultView.DepartmentName = Reader["DepartmentName"].ToString();
                studentResultView.CourseCode = Reader["Code"].ToString();
                studentResultView.CourseName = Reader["CourseName"].ToString();
                studentResultView.GradeLetter = Reader["Grade"].ToString();
                studentResultViews.Add(studentResultView);
            }
            Connection.Close();
            return studentResultViews;
        }

        public bool IsNameExsists(StudentResult studentResult)
        {

            string query = "SELECT * FROM StudentResult WHERE RegistrationNo="+studentResult.RegistrationNo+" AND CourseId="+studentResult.CourseId+"";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
    }
}