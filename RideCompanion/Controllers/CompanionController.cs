using Companion.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.ViewModels;

namespace RideCompanion.Controllers;

/// <summary>
/// 
/// </summary>
public class CompanionController : Controller
{
    private readonly IMediator _mediator;

    public CompanionController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetCompanionsQuery());
        
        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }
        
        return View(new CompanionViewModel());
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