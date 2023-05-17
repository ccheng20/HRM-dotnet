using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Recruitings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStatusById(int id)
        {
            var status = await _statusService.GetStatusById(id);
            if (status == null) return NotFound(new {error = "Status not found with this id"});
            return Ok(status);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(JobStatusRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var status = await _statusService.AddStatus(model);
            return CreatedAtAction("GetStatusById", new { Controller = "Status", id = status }, "Job Status created");
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(JobStatusRequestModel model, int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var status = await _statusService.GetStatusById(id);
            if (status == null) return NotFound();
            var updatedStatus = await _statusService.UpdateStatus(model, id);
            return Ok(updatedStatus);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var status = await _statusService.GetStatusById(id);
            if (status == null) return NotFound(new {error = "Cannot find status by this id"});
            await _statusService.DeleteStatus(id);
            return Ok(id);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var allStatus =await _statusService.GetAllStatus();
            if (!allStatus.Any())
            {
                return NotFound(new { error = "Cannot find any job status" });
            }

            return Ok(allStatus);
        }
    }
}
