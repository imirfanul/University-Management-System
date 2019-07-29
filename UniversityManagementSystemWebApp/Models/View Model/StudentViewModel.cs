using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models.View_Model
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string RegistrationNo { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
    }
}