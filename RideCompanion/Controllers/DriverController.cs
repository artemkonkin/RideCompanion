using Driver.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

public class DriverController : Controller
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(GetDriversQuery query)
    {
        var data = await _mediator.Send(query);
        return View(data);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    public IActionResult Update()
    {
        return View();
    }
    
    public IActionResult Delete()
    {
        return View();
    }
}