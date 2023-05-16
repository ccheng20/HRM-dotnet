using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;

namespace Recruitings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionsController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionsController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllSubmissions()
        {
            var submissions = await _submissionService.GetAllSubmissions();
            if (!submissions.Any()) return NotFound(new { error = "No submission found, please try later" });
            return Ok(submissions);
        }
    
        [HttpGet]
        [Route("{id:int}", Name = "GetSubmissionById")]
        public async Task<IActionResult> GetSubmissionById(int id)
        {
            var submission = await _submissionService.GetSubmissionById(id);
            if (submission == null) return NotFound();
            return Ok(submission);
        }
    
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var submission = await _submissionService.AddSubmission(model);
            return CreatedAtAction("GetSubmissionById", new {controller = "Submissions", id = submission}, "Submission Created");
        }
        
    }
}
