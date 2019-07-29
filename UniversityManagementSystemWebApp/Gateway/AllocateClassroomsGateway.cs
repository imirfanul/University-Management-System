using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystemWebApp.Models;
using UniversityManagementSystemWebApp.Models.View_Model;

namespace UniversityManagementSystemWebApp.Gateway
{
    public class AllocateClassroomsGateway : BaseGateway
    {
        public int Save(AllocateClassrooms allocateClassrooms)
        {
            string query = "INSERT INTO AllocateClassrooms VALUES(@departmentId,@courseId,@roomId,@dayId,@fromTime,@toTime,@action)";
            Command=new SqlCommand(query,Connection);
            Command.Parameters.AddWithValue("@departmentId", allocateClassrooms.DepartmentId);
            Command.Parameters.AddWithValue("@courseId", allocateClassrooms.CourseId);
            Command.Parameters.AddWithValue("@roomId", allocateClassrooms.RoomId);
            Command.Parameters.AddWithValue("@dayId", allocateClassrooms.DayId);
            Command.Parameters.AddWithValue("@fromTime", allocateClassrooms.FromTime);
            Command.Parameters.AddWithValue("@toTime", allocateClassrooms.ToTime);
            Command.Parameters.AddWithValue("@action", 1);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<AllocateClassrooms> GetTimeAllocate(int DayId,int RoomId,DateTime FromTime,DateTime ToTime)
        {
            string query = "SELECT * FROM AllocateClassrooms WHERE RoomId="+RoomId+" AND DayId="+DayId+"";
            Command=new SqlCommand(query,Connection);
            List<AllocateClassrooms> allocateClassroomses=new List<AllocateClassrooms>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                AllocateClassrooms allocate=new AllocateClassrooms();
                allocate.Id = Convert.ToInt32(Reader["Id"]);
                allocate.DepartmentId = Convert.ToInt32(Reader["DepartmentId"]);
                allocate.CourseId = Convert.ToInt32(Reader["CourseId"]);
                allocate.DayId = Convert.ToInt32(Reader["DayId"]);
                allocate.RoomId = Convert.ToInt32(Reader["RoomId"]);
                allocate.FromTime = Convert.ToDateTime(Reader["FromTime"]);
                allocate.ToTime = Convert.ToDateTime(Reader["ToTime"]);
                allocateClassroomses.Add(allocate);
            }
            Reader.Close();
            Connection.Close();
            return allocateClassroomses;
        }
        //-------------------Class Schedule------------------
        public List<ScheduleViewMode> GetAllSchedule(int departmentId)
        {
            string query = "SELECT * FROM AllocateClassroomsView WHERE DepartmentId=" + departmentId + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ScheduleViewMode> scheduleList = new List<ScheduleViewMode>();
            while (Reader.Read())
            {
                ScheduleViewMode schedule = new ScheduleViewMode();
                schedule.CourseCode = Reader["Code"].ToString();
                schedule.CourseName = Reader["Name"].ToString();
                schedule.RoomName = Reader["RoomCode"].ToString();
                schedule.DayName = Reader["Day"].ToString();
                schedule.FromTime = Convert.ToDateTime(Reader["FromTime"].ToString());
                schedule.ToTime = Convert.ToDateTime(Reader["ToTime"].ToString());
                scheduleList.Add(schedule);
            }
            Reader.Close();
            Connection.Close();
            return scheduleList;
        } 


        //-------------------Unassign Allocateclass room---------------

        public List<AllocateClassrooms> GetAllCourseByAction()
        {
            string query = "SELECT * FROM AllocateClassrooms WHERE Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AllocateClassrooms> allocateClassroomses = new List<AllocateClassrooms>();
            while (Reader.Read())
            {
                AllocateClassrooms allocate = new AllocateClassrooms();
                allocate.Id = Convert.ToInt32(Reader["Id"]);
                allocate.Action = 1;
                allocateClassroomses.Add(allocate);
            }
            Reader.Close();
            Connection.Close();
            return allocateClassroomses;
        }

        public int UpdateCourse(AllocateClassrooms allocate)
        {
            string query = "UPDATE AllocateClassrooms SET Action=0 WHERE Id=" + allocate.Id + "";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool isActionExist()
        {
            string query = "SELECT * FROM AllocateClassrooms WHERE Action=1";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool IsExsists = Reader.HasRows;
            Connection.Close();
            return IsExsists;
        }
    }
}