using EmployeeRestAPI.Dtos;
using EmployeeRestAPI.Entities;
using EmployeeRestAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly CompanyService _service;

        public CompaniesController(CompanyService companyService)
        {
            _service = companyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }

        [HttpGet("{id}/Employees")]
        public async Task<ActionResult<IEnumerable>> GetEmployees(int id)
        {
            return Ok(await _service.GetEmployeesAsync(id));
        }

        [HttpGet("{id}/EmployeesCount")]
        public async Task<ActionResult<int>> GetEmployeesCount(int id)
        {
            return Ok(await _service.GetEmployeesCountAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(Company company)
        {
            await _service.PostAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Put(Company company)
        {
            await _service.PutAsync(company);
            return NoContent();
        }
    }
}
