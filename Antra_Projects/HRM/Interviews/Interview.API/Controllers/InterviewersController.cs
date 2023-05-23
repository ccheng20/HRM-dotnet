using ApplicationCore.Contracts.Service;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewersController : ControllerBase
    {
        private readonly IInterviewersService _interviewersService;

        public InterviewersController(IInterviewersService interviewersService)
        {
            _interviewersService = interviewersService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllInterviewers()
        {
            var interviewers = await _interviewersService.GetAllInterviewers();
            if (!interviewers.Any())
                return NotFound("No interviewers found");
            return Ok(interviewers);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewerById(int id)
        {
            var interviewer = await _interviewersService.GetInterviewerById(id);
            if (interviewer == null)
                return NotFound("Interviewer not found");
            return Ok(interviewer);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddInterviewer(InterviewerRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var interviewerId = await _interviewersService.AddInterviewer(model);
            return CreatedAtAction(nameof(GetInterviewerById), new {id = interviewerId}, "Interviewer created");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterviewer(int id, InterviewerRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var interviewerId = await _interviewersService.UpdateInterviewer(id, model);
            if (interviewerId == null)
                return NotFound("Interviewer not found");
            return Ok("Interviewer updated");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterviewer(int id)
        {
            var interviewerId = await _interviewersService.DeleteInterviewer(id);
            if (interviewerId == null)
                return NotFound("Interviewer not found");
            return Ok("Interviewer deleted");
        }
    }
}
