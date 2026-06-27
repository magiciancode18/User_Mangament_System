using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.DTOs;
using UserManagment.Model;

namespace UserManagment.Service
{
    public interface IUserService
    {
        User? Login(LoginDto dto);
        string Register(RegisterDto dto);
    }
}