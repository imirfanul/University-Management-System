using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class EnrollCourse
    {
        public int Id { get; set; }
        [Required]
        public int  RegistrationNo{ get; set; }
        [Required]
        [Display(Name = "Course")]
        public int  CourseId{ get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime  Date{ get; set; }
    }
}