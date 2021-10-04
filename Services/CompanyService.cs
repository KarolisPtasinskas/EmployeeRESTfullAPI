using AutoMapper;
using EmployeeRestAPI.Dtos;
using EmployeeRestAPI.Entities;
using EmployeeRestAPI.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestAPI.Services
{
    public class CompanyService
    {
        private readonly IGenericRepository<Company> _repository;
        private readonly IGenericRepository<Employee> _employeeRepository;
        private readonly IMapper _mapper;

        public CompanyService(IGenericRepository<Company> repository, IGenericRepository<Employee> employeeRepository, IMapper mapper)
        {
            _repository = repository;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var companiesDb = await _repository.GetAllAsync();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companiesDb);
            return companiesDto;
        }

        public async Task<CompanyDto> GetByIdAsync(int id)
        {
            var companyDb = await _repository.GetByIdAsync(id);
            var companyDto = _mapper.Map<CompanyDto>(companyDb);
            return companyDto;
        }

        public async Task<IEnumerable> GetEmployeesAsync(int id)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Where(i => i.CompanyId == id).ToList();
        }
        public async Task<int> GetEmployeesCountAsync(int id)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Count(i => i.CompanyId == id);
        }

        public async Task PostAsync(Company company)
        {
            await _repository.InsertAsync(company);
        }

        public async Task Delete(int id)
        {
            var company = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(company);

        }

        public async Task PutAsync(Company company)
        {
            await _repository.UpdateAsync(company);
        }
    }
}

