using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class StatusController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}