using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniversityManagementSystemWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pleasee enter you Code")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Code must be 5 character long")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Pleasee enter you number")]
        [Range(0.5, 5, ErrorMessage = "Enter number between 0.5 to 5")]
        public float Credit { get; set; }
        [Required]
        public string Descrition { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        public int Action { get; set; }
    }
}