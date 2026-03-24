using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.DTOs;

namespace UserManagment.Service
{
    public interface IUserService
    {
        string Login(LoginDto dto);
        string Register(RegisterDto dto);
    }
}