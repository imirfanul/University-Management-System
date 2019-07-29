using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class SemesterGateway : BaseGateway
    {
        public List<SemesterModel> GetSemesters()
        {
            string query = "SELECT * FROM Semester";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<SemesterModel> semesterList = new List<SemesterModel>();
            while (Reader.Read())
            {
                SemesterModel semester = new SemesterModel();
                semester.Id = Convert.ToInt32(Reader["Id"]);
                semester.Semester = Reader["Semester"].ToString();

                semesterList.Add(semester);
            }
            Connection.Close();
            return semesterList;
        }
    }
}