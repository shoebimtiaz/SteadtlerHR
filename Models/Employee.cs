using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SteadtlerHR.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public string Manager { get; set; }
    }
}
