using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RESTfullDemo.Entities;
using RESTfullDemo.Models;
using RESTfullDemo.Services;

namespace RESTfullDemo.Controllers
{
    [ApiController]
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public EmployeesController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees(Guid companyId, string gender)
        {
            if (await _companyRepository.CompanyExistsAsync(companyId))
            {
                var employees = await _companyRepository.GetEmployeesAsync(companyId, gender);

                var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

                if (employeesDto == null)
                {
                    return NoContent();
                }
                return Ok(employeesDto);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{employeeId}", Name =nameof(GetEmployee))]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(Guid companyId, Guid employeeId)
        {
            if (await _companyRepository.CompanyExistsAsync(companyId))
            {
                var employee = await _companyRepository.GetEmployeeAsync(companyId, employeeId);
                if (employee == null)
                {
                    return NotFound();
                }
                var employeeDto = _mapper.Map<EmployeeDto>(employee);

                return Ok(employeeDto);

            }
            else
            {
                return NotFound();
            }
        }

        public async Task<ActionResult<EmployeeDto>> CreateEmployee(Guid companyId, EmployeeAddDto employee)
        {
            if (await _companyRepository.CompanyExistsAsync(companyId))
            {
                var entity = _mapper.Map<Employee>(employee);
                _companyRepository.AddEmployee(companyId, entity);
                await _companyRepository.SaveAsync();
                var dtoToReturn = _mapper.Map<EmployeeDto>(entity);
                return CreatedAtRoute(nameof(GetEmployee), new { companyId = companyId, employeeId = entity.Id }, dtoToReturn);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
