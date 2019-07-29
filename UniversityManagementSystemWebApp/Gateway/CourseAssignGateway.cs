using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class CourseAssignGateway : BaseGateway
    {
        string Total_Credit;
        public int Save(CourseAssign courseAssign)
        {
            string query = "INSERT INTO CourseAssign VALUES(@departmentId,@teacherId,@courseCode)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@departmentId", courseAssign.DepartmentId);
            Command.Parameters.AddWithValue("@teacherId", courseAssign.TeacherId);

            Command.Parameters.AddWithValue("@courseCode", courseAssign.CourseCode);


            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<CourseAssignViewModel> GetTeachersByDepartmentId(int departmentId)
        {
            string query = "SELECT Teacher.Name AS TeacherName,Teacher.Id AS TeacherId,Teacher.CreditToken FROM Department INNER JOIN Teacher ON Teacher.DepartmentId=Department.Id WHERE Department.Id=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssignViewModel> courseAssignViewModels = new List<CourseAssignViewModel>();
            while (Reader.Read())
            {
                CourseAssignViewModel courseAssignViewModel = new CourseAssignViewModel();
                courseAssignViewModel.Id = Convert.ToInt32(Reader["TeacherId"]);
                courseAssignViewModel.Name = Reader["TeacherName"].ToString();
                courseAssignViewModel.CreditToken = Convert.ToSingle(Reader["CreditToken"]);
                courseAssignViewModels.Add(courseAssignViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseAssignViewModels;
        }

        public List<CourseAssignViewModel> GetCoursesByDepartmentId(int departmentId)
        {
            string query = "SELECT Course.Code,Course.Id AS CourseId FROM Department INNER JOIN Course ON Department.Id=Course.DepartmentId WHERE Department.Id="+departmentId+" AND Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseAssignViewModel> courseAssignViewModels = new List<CourseAssignViewModel>();
            while (Reader.Read())
            {
                CourseAssignViewModel courseAssignViewModel = new CourseAssignViewModel();
                courseAssignViewModel.CourseId = Convert.ToInt32(Reader["CourseId"]);
                courseAssignViewModel.CourseCode = Reader["Code"].ToString();
                courseAssignViewModels.Add(courseAssignViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseAssignViewModels;
        }

        public List<Course> GetCourseCode(int courseCode)
        {
            string query = "SELECT Id,Name,Credit FROM Course WHERE Id='" + courseCode + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            List<Course> courses = new List<Course>();
            if (Reader.HasRows)
            {
                Course course = new Course();
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Name = Reader["Name"].ToString();
                course.Credit = float.Parse(Reader["Credit"].ToString());
                courses.Add(course);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }        
        public bool IsSubjectExsists(CourseAssign courseAssign)
        {

            string query = "SELECT * FROM CourseAssign WHERE CourseCode='" + courseAssign.CourseCode + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }

        public Course GetCourseId(int codeId)
        {
            string query = "SELECT Id,Name,Credit FROM Course WHERE Id='" + codeId + "' AND Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Course course = new Course();
            if (Reader.HasRows)
            {
                course.Id = Convert.ToInt32(Reader["Id"]);
                course.Credit = Convert.ToSingle(Reader["Credit"]);
                course.Name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return course;
        }
        public int UpdateTeacher(int Id, float remainingCredit)
        {

            string query = "UPDATE Teacher SET ReminingCredit='" + remainingCredit + "' WHERE Id=" + Id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public Teacher GetAvailableCreditByTeacherId(int teacherId)
        {
            string query = "SELECT ReminingCredit FROM Teacher WHERE Id="+teacherId+"";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            Teacher teacher = new Teacher();
            if (Reader.HasRows)
            {
                teacher.ReminingCredit = Convert.ToSingle(Reader["ReminingCredit"]);
            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }

        public List<CourseStaticViewModel> GetCourseInfo(int departmentId)
        {
            string query = "SELECT Course.Code,Course.Name,Semester.Semester," +
                           "ISNULL(Teacher.Name,'Not Assigned Yet') AS TeacherAssign" +
                           " FROM Course LEFT JOIN CourseAssign ON Course.Id=CourseAssign.CourseCode" +
                           " LEFT JOIN Teacher ON CourseAssign.TeacherId=Teacher.Id" +
                           " LEFT JOIN Semester ON Course.SemesterId=Semester.Id WHERE" +
                           " Course.DepartmentId="+departmentId+" AND Action=1";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<CourseStaticViewModel> courseStaticViewModels=new List<CourseStaticViewModel>();
            while (Reader.Read())
            {
                CourseStaticViewModel courseStaticViewModel=new CourseStaticViewModel();
                courseStaticViewModel.Code = Reader["Code"].ToString();
                courseStaticViewModel.Name = Reader["Name"].ToString();
                courseStaticViewModel.Semester = Reader["Semester"].ToString();
                courseStaticViewModel.Teacher = Reader["TeacherAssign"].ToString();
                courseStaticViewModels.Add(courseStaticViewModel);
            }
            Reader.Close();
            Connection.Close();
            return courseStaticViewModels;
        }

        public bool CheckAssignCourseEntry(string Id)
        {
            Connection.Open();

            string query = "select * from AssignedCourse where Id = '" + Id + "'";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            bool Check = Reader.HasRows;

            Connection.Close();
            return Check;
        }
        public string GetTotalCredit(string Id)
        {
            Connection.Open();

            string query = "select sum(CreditTaken) as TotalCredit from AssignedCourse where Id = '" + Id + "'";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                 Total_Credit = Reader["CreditTaken"].ToString();
            }

            Connection.Close();

            return Total_Credit;
        }
    }
}