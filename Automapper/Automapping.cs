using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using UserManagment.DTOs;
using UserManagment.Model;

namespace UserManagment.Automapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeDto , Employee>();
             CreateMap<Employee , EmployeeDto>();
        }
    }
}