using MediatR;
using Microsoft.AspNetCore.Mvc;
using Trip.App.Queries;

namespace RideCompanion.Controllers;

/// <summary>
/// 
/// </summary>
public class TripController : Controller
{
    private readonly IMediator _mediator;

    public TripController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(GetTripsQuery query)
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