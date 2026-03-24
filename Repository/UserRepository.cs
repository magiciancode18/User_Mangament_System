using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Data;
using UserManagment.Model;

namespace UserManagment.Repository
{
    public class UserRepository : IUserRepository
    {
        AppDbContext appDb;
        public UserRepository(AppDbContext _appDb)
        {
            appDb = _appDb;
        }
        int IUserRepository.AddUser(User u)
        {
            appDb.users.Add(u);
            var item = appDb.SaveChanges();
            return item;
        }

        User IUserRepository.GetuserbyEmail(string email)
        {
            var result = appDb.users.FirstOrDefault(t=>t.Email==email);
            return result;
        }
    }
}