using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace RecrutingWeb.Controllers;

public class JobsController : Controller
{
    private IJobService _jobService;
    public JobsController(IJobService jobService)
    {
        _jobService = jobService;
    }
    // GET
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        // return all the jobs
        // call the job service
        ViewBag.PageTitle = "Showing jobs"; // viewBag
        var jobs = await _jobService.GetAllJobs();
        return View(jobs); // send data through strongly typed model
    }

    // get the job detail information
    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var job = await _jobService.GetJobById(id);
        return View(job);
    }
    


    //show the empty page
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(JobRequestModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _jobService.AddJob(model);
        //save the data in database
        // return to the index view
        return RedirectToAction("Index");
    }
}