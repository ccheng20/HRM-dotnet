using Microsoft.AspNetCore.Mvc;

namespace RecruitingWeb.Controllers;

public class EmployeeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}