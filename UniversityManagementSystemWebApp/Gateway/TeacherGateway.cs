using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class TeacherGateway : BaseGateway
    {
        public int Save(Teacher teacher)
        {
            string query = "INSERT INTO Teacher VALUES(@name,@address,@email,@contact,@designationId,@departmentId,@credittoken,@reminingCredit)";
            Command = new SqlCommand(query, Connection);
            Command.Parameters.AddWithValue("@name", teacher.Name);
            Command.Parameters.AddWithValue("@address", teacher.Address);
            Command.Parameters.AddWithValue("@email", teacher.Email);
            Command.Parameters.AddWithValue("@contact", teacher.Contact);
            Command.Parameters.AddWithValue("@designationId", teacher.DesignationId);
            Command.Parameters.AddWithValue("@departmentId", teacher.DepartmentId);
            Command.Parameters.AddWithValue("@credittoken", teacher.CreditToken);
            Command.Parameters.AddWithValue("@reminingCredit", teacher.CreditToken);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsNameExsists(Teacher teacher)
        {

            string query = "SELECT * FROM Teacher WHERE Name='" + teacher.Name + "' OR Email='"+teacher.Email+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
       

        public List<Teacher> GetTeacherId(int teacherId)
        {
            string query = "SELECT Id,Name,CreditToken,ReminingCredit FROM Teacher WHERE Id='" + teacherId + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Reader.Read();
            List<Teacher> teachers = new List<Teacher>();
            if (Reader.HasRows)
            {
                Teacher aTeacher=new Teacher();
                aTeacher.Id = Convert.ToInt32(Reader["Id"]);
                aTeacher.Name = Reader["Name"].ToString();
                aTeacher.CreditToken = Convert.ToSingle(Reader["CreditToken"]);
                aTeacher.ReminingCredit = Convert.ToSingle(Reader["ReminingCredit"]);
                teachers.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
        public List<Teacher> GetCreditTaken(string Id)
        {
            Connection.Open();

            string query = "select * from Teacher where Id = '" + Id + "'";
            Command = new SqlCommand(query, Connection);
            Reader = Command.ExecuteReader();
            List<Teacher> listInformation = new List<Teacher>();

            while (Reader.Read())
            {
                Teacher inforamtion = new Teacher();

                inforamtion.CreditToken = Convert.ToDouble(Reader["CreditToken"]);

                listInformation.Add(inforamtion);
            }

            Connection.Close();

            return listInformation;
        }

    }
}