using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagment.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string? EmployeeName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public decimal Salary { get; set; }

    }
}