using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.View_Model
{
    public class ScheduleViewMode
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomName { get; set; }
        public string DayName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public string Schedule { get; set; }
    }
}