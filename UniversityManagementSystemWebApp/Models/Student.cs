using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Required]
        public string RegistrationNo { get; set; }
        [Required]
        [RegularExpression("[a-zA-Z ]*$", ErrorMessage = "Numaric Value are Not allowed")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Contact No must be 11 number long")]
        public string Contact { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [Display(Name = "Date")]
        public DateTime RegisterDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }
    }
}