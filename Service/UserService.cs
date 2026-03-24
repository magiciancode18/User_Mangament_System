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
            ur =_ur;
        }
        string IUserService.Login(LoginDto dto)
        {
            var user = ur.GetuserbyEmail(dto.Email);

            if (user == null)
            {
                return "User not found";
            }

            // Check password
            if (user.Password != dto.Password)
            {
                return "Invalid password";
            }

            return "Login successful";
        }

        string IUserService.Register(RegisterDto dto)
        {
            var existingUser = ur.GetuserbyEmail(dto.Email);

            if (existingUser != null)
            {
                return "User already exists";
            }

           
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = dto.Password
            };

            ur.AddUser(user);

            return "User registered successfully";

        }
    }
}