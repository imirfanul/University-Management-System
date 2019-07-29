using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class RoomGateway : BaseGateway
    {
        public List<Room> GetAllRoomCode()
        {
            string query = "SELECT * FROM Room";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Room> roomList = new List<Room>();
            while (Reader.Read())
            {
                Room room = new Room();
                room.Id = Convert.ToInt32(Reader["Id"]);
                room.RoomCode = Reader["RoomCode"].ToString();

                roomList.Add(room);
            }
            Connection.Close();
            return roomList;
        } 
    }
}