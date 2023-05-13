using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
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
    }
}
