using AutoMapper;
using EmployeeRestAPI.Dtos;
using EmployeeRestAPI.Entities;
using EmployeeRestAPI.Repositories;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeRestAPI.Services
{
    public class EmployeeService
    {
        private readonly IGenericRepository<Employee> _repository;
        private readonly IMapper _mapper;

        public EmployeeService(IGenericRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable> GetAllAsync()
        {
            var employeesDb = await _repository.GetAllAsync();
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesDb);
            return employeesDto;
        }

        public async Task<EmployeeDto> GetByIdAsync(int id)
        {
            var employeeDb = await _repository.GetByIdAsync(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employeeDb);
            return employeeDto;
        }

        public async Task PostAsync(Employee employee)
        {
            await _repository.InsertAsync(employee);
        }

        public async Task Delete(int id)
        {
            var employee = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(employee);

        }

        public async Task PutAsync(Employee employee)
        {
            await _repository.UpdateAsync(employee);
        }
    }
}
