using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.View_Model
{
    public class CourseAssignViewModel
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }
        public float CreditToken { get; set; }
        public float RemainingCredit { get; set; }
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string Name { get; set; }
        public float Credit { get; set; }
    }
}