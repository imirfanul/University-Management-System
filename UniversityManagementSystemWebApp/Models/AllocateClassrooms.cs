using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class AllocateClassrooms
    {
        public int Id { get; set; }
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
        [Display(Name = "Course")]
        public int CourseId { get; set; }
        [Display(Name = "Room No")]
        public int RoomId { get; set; }
        [Display(Name = "Day")]
        public int DayId { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "From")]
        public DateTime FromTime { get; set; }
        [DataType(DataType.Time)]
        [Display(Name = "To")]
        public DateTime ToTime { get; set; }
        public int Action { get; set; }
    }
}