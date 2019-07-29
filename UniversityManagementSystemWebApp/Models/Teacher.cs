using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Xsl;

namespace UniversityManagementSystemWebApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*", ErrorMessage = "Numaric Value are Not allowed")]
        public string Address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact No must be 11 number long")]
        public string Contact { get; set; }
        [Required]
        [Display(Name = "Designation")]
        public int DesignationId { get; set; }
        [Required]
        [Display (Name = "Department")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Pleasee enter you Credit")]
        [Range(1, 999, ErrorMessage = "You are not type of negative value")]
        [Display(Name = "CreditTaken")]
        public Double CreditToken { get; set; }
        public Double ReminingCredit { get; set; }
    }
}