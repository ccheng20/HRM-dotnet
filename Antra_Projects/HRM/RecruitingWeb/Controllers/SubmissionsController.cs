using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class SubmissionsController : Controller
{
    private IJobService _jobService;
    private ISubmissionService _submissionService;

    public SubmissionsController(IJobService jobService, ISubmissionService submissionService)
    {
        _jobService = jobService;
        _submissionService = submissionService;
    }

    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Create(int id)
    {
        var job = await _jobService.GetJobById(id);
        ViewData["Job"] = job;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SubmissionRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        var job = ViewData["Job"] as JobResponseModel;
        await _submissionService.AddSubmission(model, job);
        return RedirectToAction("Index");
    }
}