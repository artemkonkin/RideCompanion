using Driver.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

public class DriverController : Controller
{
    private IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IActionResult> Index(GetDriverByUserIdQuery query)
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