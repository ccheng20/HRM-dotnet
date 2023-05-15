using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Recruiting.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }
        
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            var candidates = await _candidateService.GetAllCandidates();
            if (!candidates.Any())
            {
                return NotFound(new { error = "No candidate found, please try later" });
            }

            return Ok(candidates);
        }

        [Route("{id:int}", Name = "GetCandidateById")]
        [HttpGet]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var candidate = await _candidateService.GetCandidateById(id);
            if (candidate == null)
            {
                return NotFound(new { error = "No candidate found by this id" });
            }

            return Ok(candidate);
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var candidate = await _candidateService.AddCandidate(model);
            return CreatedAtAction("GetCandidateById", new { Controller = "Candidates", id = candidate },
                "Candidate created");
        }
    }
}
