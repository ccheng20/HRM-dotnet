using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Service; 
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interview.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewTypesController : ControllerBase
    {
        private readonly IInterviewTypeLookUpService _interviewTypeLookUpService;

        public InterviewTypesController(IInterviewTypeLookUpService interviewTypeLookUpService)
        {
            _interviewTypeLookUpService = interviewTypeLookUpService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var interviewType = await _interviewTypeLookUpService.GetInterviewTypeById(id);
            if (interviewType == null) return NotFound();
            return Ok(interviewType);
        }

        [HttpPost("")]
        public async Task<IActionResult> Create(InterviewTypeRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var type = await _interviewTypeLookUpService.AddInterviewType(model);
            return CreatedAtAction("GetById", new { controller = "InterviewTypes", id = type },
                "Interview type created");
        }
        
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            var interviewTypes = await _interviewTypeLookUpService.GetAllTypes();
            if (interviewTypes == null) return NotFound();
            return Ok(interviewTypes);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InterviewTypeRequestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();
            var interviewType = await _interviewTypeLookUpService.GetInterviewTypeById(id);
            if (interviewType == null) return NotFound();
            var updatedInterviewType =  await _interviewTypeLookUpService.UpdateInterviewType(id, model);
            return Created("GetById", updatedInterviewType);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var interviewType = await _interviewTypeLookUpService.GetInterviewTypeById(id);
            if (interviewType == null) return NotFound();
            var deletedInterviewType = await _interviewTypeLookUpService.DeleteInterviewType(id);
            return Ok(deletedInterviewType);
        }
    }
}
