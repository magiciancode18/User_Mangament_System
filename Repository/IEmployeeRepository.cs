using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.Model;

namespace UserManagment.Repository
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmpolyees();
        int AddEmployee(Employee emp);
        int EditEmployee(Employee emp);
        Employee? SearchbyName(string name);
        bool DeleteEmployee(string name);
    }
}