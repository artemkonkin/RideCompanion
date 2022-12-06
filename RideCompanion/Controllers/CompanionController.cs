using Companion.App.Commands;
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
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> GetCompanionById(Guid id)
    {
        var data = await _mediator.Send(new GetCompanionByIdQuery(id));
        return Json(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> CreateCompanion(CompanionViewModel viewModel)
    {
        await _mediator.Send(new CreateCompanionCommand(viewModel.CompanionDto));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> UpdateCompanion(CompanionViewModel viewModel)
    {
        await _mediator.Send(new UpdateCompanionCommand(viewModel.CompanionDto));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteCompanion(Guid id)
    {
        await _mediator.Send(new DeleteCompanionCommand(id));
        return RedirectToAction("Index");
    }
}