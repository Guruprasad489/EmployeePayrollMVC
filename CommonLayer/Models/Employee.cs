using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Models
{
    public class Employee
    {
        public int EmpId { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        [RegularExpression(@"^[A-Z]{1}[a-z]{2,}$", ErrorMessage = "Name is not valid")]
        public string Name { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ProfileImage { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        [RegularExpression(@"^[mMfF]$", ErrorMessage = "Gender is not valid, Should be M or F")]
        public Char Gender { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public string Dept { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        public float Salary { get; set; }

        [Required(ErrorMessage = "{0} should not be empty")]
        [DataType(DataType.DateTime)]
        public DateTime Startdate { get; set; }

        public string Notes { get; set; }
    }
}
