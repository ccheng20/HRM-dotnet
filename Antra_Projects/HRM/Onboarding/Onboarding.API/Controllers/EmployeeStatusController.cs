using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Onboarding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeStatusController : ControllerBase
    {
        private readonly IEmployeeStatusLookUpService _employeeStatusLookUpService;

        public EmployeeStatusController(IEmployeeStatusLookUpService employeeStatusLookUpService)
        {
            _employeeStatusLookUpService = employeeStatusLookUpService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeStatuses()
        {
            var employeeStatuses = await _employeeStatusLookUpService.GetAllEmployeeStatusesAsync();
            if(!employeeStatuses.Any())
                return NotFound("No employee statuses found");
            return Ok(employeeStatuses);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeStatusById(int id)
        {
            var employeeStatus = await _employeeStatusLookUpService.GetEmployeeStatusByIdAsync(id);
            if(employeeStatus == null)
                return NotFound($"Employee status with id {id} not found");
            return Ok(employeeStatus);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddEmployeeStatus(EmployeeStatusRequestModel employeeStatusLookUpRequestModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var id = await _employeeStatusLookUpService.AddEmployeeStatusAsync(employeeStatusLookUpRequestModel);
            return CreatedAtAction(nameof(GetEmployeeStatusById), new {id}, "Employee status created successfully");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeStatus(int id, EmployeeStatusRequestModel employeeStatusLookUpRequestModel)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            await _employeeStatusLookUpService.UpdateEmployeeStatusAsync(id, employeeStatusLookUpRequestModel);
            return Ok("Employee status updated successfully");
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployeeStatus(int id)
        {
            await _employeeStatusLookUpService.DeleteEmployeeStatusAsync(id);
            return Ok("Employee status deleted successfully");
        }
    }
}
