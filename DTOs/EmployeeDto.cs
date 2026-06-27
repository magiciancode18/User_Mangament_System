using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagment.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        public string? EmployeeName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Range(1, double.MaxValue)]
        public decimal Salary { get; set; }
    }
}