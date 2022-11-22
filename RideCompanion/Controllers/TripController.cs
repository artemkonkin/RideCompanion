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
    /// 
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public async Task<IActionResult> Index(GetTripsQuery query)
    {
        await _mediator.Send(query);
        ViewBag.drivers = 0;
        return View();
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