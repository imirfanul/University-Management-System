using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class GradeLetterGateway : BaseGateway
    {
        public List<GradeLetter> GetAllGrade()
        {
            string query = "SELECT * FROM GradeLetter";
            Command=new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<GradeLetter> gradeLetters=new List<GradeLetter>();
            while (Reader.Read())
            {
                GradeLetter grade=new GradeLetter();
                grade.Id = Convert.ToInt32(Reader["Id"]);
                grade.Grade = Reader["GradeLetter"].ToString();
                gradeLetters.Add(grade);
            }
            Reader.Close();
            Connection.Close();
            return gradeLetters;
        } 
    }
}