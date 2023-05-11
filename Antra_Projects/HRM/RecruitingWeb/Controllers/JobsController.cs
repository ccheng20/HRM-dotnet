using ApplicationCore.Contracts.Services;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
    private IJobService _jobService;
    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        // return all the jobs
        // call the job service
        ViewBag.PageTitle = "Showing jobs"; // viewBag
        var jobs = _jobService.GetAllJobs();
        return View(jobs); // send data through strongly typed model
    }

    // get the job detail information
    [HttpGet]
    public IActionResult Details(int id)
    {
        var job = _jobService.GetJobById(id);
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        return View();
    }
}