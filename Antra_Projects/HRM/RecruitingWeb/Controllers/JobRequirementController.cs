using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class JobRequirementController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}