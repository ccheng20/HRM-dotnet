using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobsController : Controller
{
    // GET
    [HttpGet]
    public IActionResult Index()
    {
        // return all the jobs
        return View();
    }

    // get the job detail information
    [HttpGet]
    public IActionResult Details(int id)
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create()
    {
        return View();
    }
}