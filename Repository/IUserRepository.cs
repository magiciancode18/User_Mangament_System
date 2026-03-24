using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Model;

namespace UserManagment.Repository
{
    public interface IUserRepository
    {
        User GetuserbyEmail(string email);
       int AddUser(User u);
    }
}