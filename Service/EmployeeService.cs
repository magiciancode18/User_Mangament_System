using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagment.DTOs;
using UserManagment.Model;
using UserManagment.Repository;

namespace UserManagment.Service
{
    public class EmployeeService : IEmpoloyeeService
    {
        private readonly IEmployeeRepository repository;
        private readonly IMapper mapper;
        public EmployeeService(IEmployeeRepository _repository , IMapper _mapper)
        {
            this.repository = _repository;
            this.mapper = _mapper;
        }
        string IEmpoloyeeService.AddAllEmployee(EmployeeDto dto)
        {
            var existingemp = repository.SearchbyName(dto.EmployeeName);
            if (existingemp != null)
            {
                return "Employee Already Exist Here";
            }

            var employee = mapper.Map<Employee>(dto);
            repository.AddEmployee(employee);

            return "Employee add Successfully";
        }

        bool IEmpoloyeeService.DeleteEmployees(string name)
        {
            return repository.DeleteEmployee(name);
        }

        IEnumerable<EmployeeDto> IEmpoloyeeService.GetAllEmployees()
        {
            var res = repository.GetEmpolyees();
            return mapper.Map<IEnumerable<EmployeeDto>>(res);
        }

        EmployeeDto? IEmpoloyeeService.SearchName(string name)
        {
            var employee = repository.GetEmpolyees().FirstOrDefault(t=>t.EmployeeName == name);
            return mapper.Map<EmployeeDto>(employee);
        }

        int IEmpoloyeeService.Update(EmployeeDto dto)
        {
            var emp = mapper.Map<Employee>(dto);
            if(emp == null)
            {
                return 0;
            }
            return repository.EditEmployee(emp);
        }
    }
}