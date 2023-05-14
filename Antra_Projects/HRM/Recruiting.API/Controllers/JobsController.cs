using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    // Attribute Routing
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobsController(IJobService jobService)
        {
            _jobService = jobService;
        }
        
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            if (!jobs.Any())
            {
                // no job exists
                return NotFound(new {error = "No open jobs found, please try later"});
            }
            // return json data and also Http status code, 200 = ok
            // serialization => convert c# objects into Json Objects using System.Text
            return Ok(jobs);
        }
        [Route("{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetJobById(int id)
        {
            var job = await _jobService.GetJobById(id);
            if (job == null)
            {
                return NotFound(new { error = "No job found for this id" });
            }

            return Ok(job);
        }
    }
}
