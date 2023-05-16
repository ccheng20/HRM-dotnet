using Microsoft.AspNetCore.Mvc;

namespace RecrutingWeb.Controllers;

public class CandidatesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}