using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class DayGateway : BaseGateway
    {
        public List<DayModel> GetAllDay()
        {
            string query = "SELECT * FROM Day";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<DayModel> dayList = new List<DayModel>();
            while (Reader.Read())
            {
                DayModel day = new DayModel();
                day.Id = Convert.ToInt32(Reader["Id"]);
                day.Day = Reader["Day"].ToString();

                dayList.Add(day);
            }
            Connection.Close();
            return dayList;
        } 
    }
}