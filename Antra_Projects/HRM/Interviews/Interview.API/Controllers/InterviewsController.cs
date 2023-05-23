using ApplicationCore.Contracts.Service;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewsService _interviewsService;

        public InterviewsController(IInterviewsService interviewsService)
        {
            _interviewsService = interviewsService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllInterviews()
        {
            var interviews = await _interviewsService.GetAllInterviews();
            if (!interviews.Any())
                return NotFound("No interviews found");
            return Ok(interviews);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInterviewById(int id)
        {
            var interview = await _interviewsService.GetInterviewById(id);
            if (interview == null)
                return NotFound("Interview not found");
            return Ok(interview);
        }
        
        [HttpPost]
        public async Task<IActionResult> AddInterview(InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var interviewId = await _interviewsService.AddInterview(model);
            return CreatedAtAction(nameof(GetInterviewById), new {id = interviewId}, "Interview created");
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateInterview(int id, InterviewRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var interviewId = await _interviewsService.UpdateInterview(model, id);
            if (interviewId == null)
                return NotFound("Interview not found");
            return Ok("Interview updated");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInterview(int id)
        {
            var interviewId = await _interviewsService.DeleteInterview(id);
            if (interviewId == null)
                return NotFound("Interview not found");
            return Ok("Interview deleted");
        }
    }
}
