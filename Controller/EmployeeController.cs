using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagment.DTOs;
using UserManagment.Repository;
using UserManagment.Service;

namespace UserManagment.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpoloyeeService service;
        private readonly IUserRepository userRepository;
        public EmployeeController(IEmpoloyeeService _service, IUserRepository _userRepository)
        {
            this.service = _service;
            this.userRepository = _userRepository;

        }
        [HttpGet("AllEmployees")]
        public IActionResult GetEmployees()
        {
            var Employees = service.GetAllEmployees();
            return Ok(Employees);
        }


        [HttpPost("Add")]
        public IActionResult AddEmployees([FromBody] EmployeeDto dto, [FromQuery] string email)
        {
            var user = userRepository.GetuserbyEmail(email);

            if (user == null || user.Role != "Admin")
            {
                return Unauthorized("Only Admin can add employees");
            }

            var result = service.AddAllEmployee(dto);

            return Ok(result);
        }

        [HttpPut("Update")]
        public IActionResult EditEmployee([FromBody] EmployeeDto dto, [FromQuery] string email)
        {
            var user = userRepository.GetuserbyEmail(email);

            if (user == null || user.Role != "Admin")
            {
                return Unauthorized("Only Admin can update employees");
            }

            var result = service.Update(dto);

            if (result == 0)
            {
                return NotFound("Employee not found");
            }

            return Ok("Employee updated successfully");
        }

        [HttpGet("searchEmployee")]
        public IActionResult SearchEmployee(string name)
        {
            var emp = service.SearchName(name);

            if (emp == null)
            {
                return NotFound("Employee not found");
            }

            return Ok(emp);
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteEmployee([FromQuery] string name, [FromQuery] string email)
        {
            var user = userRepository.GetuserbyEmail(email);

            if (user == null || user.Role != "Admin")
            {
                return Unauthorized("Only Admin can delete employees");
            }

            var result = service.DeleteEmployees(name);

            if (!result)
            {
                return NotFound("Employee not found");
            }

            return Ok("Employee deleted successfully");
        }
    }
}