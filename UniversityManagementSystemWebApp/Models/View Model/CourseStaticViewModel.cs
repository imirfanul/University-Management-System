using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.View_Model
{
    public class CourseStaticViewModel
    {
        public int DepartmentId { get; set; }
        public string Teacher { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Semester { get; set; }
    }
}