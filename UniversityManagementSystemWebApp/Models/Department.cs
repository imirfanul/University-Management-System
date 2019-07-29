using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystemWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Required]
        [StringLength(7, ErrorMessage = "Code must be 2 to 7 character long", MinimumLength = 2)]
        public string Code { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z ]*", ErrorMessage = "Numaric Value are Not allowed")]
        public string Name { get; set; }
    }
}