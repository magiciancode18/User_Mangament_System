using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagment.DTOs;

namespace UserManagment.Service
{
    public interface IEmpoloyeeService
    {
        IEnumerable<EmployeeDto> GetAllEmployees();
        string AddAllEmployee(EmployeeDto dto);
        int Update(EmployeeDto dto);
        EmployeeDto? SearchName(string name);
        bool DeleteEmployees(string name);
    }
}