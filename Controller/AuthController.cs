using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UserManagment.Service;
using UserManagment.DTOs;

namespace UserManagment.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IUserService us;
        public AuthController(IUserService _us)
        {
            us = _us;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var result = us.Register(dto);

            if (result == "User already exists")
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = us.Login(dto);

            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(new
            {
                email = user.Email,
                userName = user.UserName,
                role = user.Role
            });
        }

    }
}