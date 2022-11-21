using Companion.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(GetCompanionsQuery query)
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