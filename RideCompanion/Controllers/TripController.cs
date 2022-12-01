using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.ViewModels;
using Trip.App.Commands;
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
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetTripsQuery());
        
        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }
        
        return View(new TripViewModel());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> GetTripById(Guid id)
    {
        var data = await _mediator.Send(new GetTripByIdQuery(id));
        return Json(data);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> CreateTrip(TripViewModel viewModel)
    {
        await _mediator.Send(new CreateTripCommand(viewModel.TripDto));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="viewModel"></param>
    /// <returns></returns>
    public async Task<IActionResult> UpdateTrip(TripViewModel viewModel)
    {
        await _mediator.Send(new UpdateTripCommand(viewModel.TripDto));
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> DeleteTrip(Guid id)
    {
        await _mediator.Send(new DeleteTripCommand(id));
        return RedirectToAction("Index");
    }
}