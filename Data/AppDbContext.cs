using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserManagment.Model;

namespace UserManagment.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions d):base (d)
        {
            
        }

        public DbSet<User> users{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User{UserId= 1, UserName="Shivam kumar", Email="shiv@gmail.com", Password="admin@321"}
            );
        }
    }
}