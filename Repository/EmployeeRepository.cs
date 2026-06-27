using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Data;
using UserManagment.Model;

namespace UserManagment.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDb;
        public EmployeeRepository(AppDbContext _appDb)
        {
            this.appDb = _appDb;
        }
        int IEmployeeRepository.AddEmployee(Employee emp)
        {
            appDb.employees.Add(emp);
            var res = appDb.SaveChanges();
            return res;
        }

        bool IEmployeeRepository.DeleteEmployee(string name)
        {
            var item = appDb.employees.FirstOrDefault(t=>t.EmployeeName == name);
            if(item == null)
            {
                return false;
            }
            appDb.employees.Remove(item);
            appDb.SaveChanges();

            return true;
        }

        int IEmployeeRepository.EditEmployee(Employee emp)
        {
            var E = appDb.employees.FirstOrDefault(t=>t.Id == emp.Id);

            if(E == null)
            {
                return 0;
            }
            E.EmployeeName = emp.EmployeeName;
            E.Email = emp.Email;
            E.PhoneNumber = emp.PhoneNumber;
            E.Salary = emp.Salary;

            return appDb.SaveChanges();
        }

        IEnumerable<Employee> IEmployeeRepository.GetEmpolyees()
        {
            return appDb.employees.ToList();
        }

        Employee? IEmployeeRepository.SearchbyName(string name)
        {
            var res = appDb.employees.FirstOrDefault(t=>t.EmployeeName == name);
            return res;
        }
    }
}