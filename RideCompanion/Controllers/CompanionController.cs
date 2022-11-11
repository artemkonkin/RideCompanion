using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

public class CompanionController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}