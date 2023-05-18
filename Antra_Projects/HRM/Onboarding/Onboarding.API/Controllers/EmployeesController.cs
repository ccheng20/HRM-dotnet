using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            if(!employees.Any())
                return NotFound("No employees found");
            return Ok(employees);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if(employee == null)
                return NotFound($"Employee with id {id} not found");
            return Ok(employee);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeRequestModel employeeRequestModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _employeeService.AddEmployeeAsync(employeeRequestModel);
            return CreatedAtAction(nameof(GetEmployeeById), new {id}, "Employee created successfully");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeRequestModel employeeRequestModel)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _employeeService.UpdateEmployeeAsync(id, employeeRequestModel);
            return Ok();
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee==null)
                return NotFound($"Employee with id {id} not found");
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
