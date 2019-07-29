using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class ClassSchedule
    {
        public int CourseId { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Schedule { get; set; }
    }
}