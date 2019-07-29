using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class StudentResult
    {
        public int Id { get; set; }
        [Required]
        public string RegistrationNo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        [Display (Name = "Course")]
        public int CourseId { get; set; }
        [Required]
        [Display (Name = "Grade Letter")]
        public int GradeLetterId { get; set; }
    }
}