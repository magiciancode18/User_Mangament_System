using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Data;
using UserManagment.DTOs;
using UserManagment.Model;
using UserManagment.Repository;

namespace UserManagment.Service
{

    public class UserService : IUserService
    {
        IUserRepository ur;
        public UserService(IUserRepository _ur)
        {
            ur = _ur;
        }

        User? IUserService.Login(LoginDto dto)
        {
            var user = ur.GetuserbyEmail(dto.Email);

            if (user == null)
                return null;

            if (user.Password != dto.Password)
                return null;

            return user;

        }


        string IUserService.Register(RegisterDto dto)
        {
            var existingUser = ur.GetuserbyEmail(dto.Email);

            if (existingUser != null)
            {
                return "User already exists";
            }

            if (dto.Role != "Admin" && dto.Role != "User")
            {
                return "Invalid Role";
            }

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password,
                Role = dto.Role
            };

            ur.AddUser(user);

            if (dto.Role == "Admin")
            {
                return "Admin registered successfully";
            }

            return "User registered successfully";
        }
    }
}