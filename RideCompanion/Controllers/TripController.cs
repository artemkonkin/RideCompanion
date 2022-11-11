using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

public class TripController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}