using AutoMapper;
using EmployeeRestAPI.Dtos;
using EmployeeRestAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestAPI.AutoMapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Company, CompanyDto>();
        }
    }
}
