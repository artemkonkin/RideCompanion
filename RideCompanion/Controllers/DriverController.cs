using Driver.App.Commands;
using Driver.App.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.ViewModels;

namespace RideCompanion.Controllers;

/// <summary>
/// Driver
/// </summary>
public class DriverController : Controller
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Index
    /// </summary>
    /// <returns> View </returns>
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetDriversQuery());
        
        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }
        
        return View(new DriverViewModel());
    }

    /// <summary>
    /// Get driver by Id
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Driver entity </returns>
    public async Task<IActionResult> GetDriverById(Guid id)
    {
        var data = await _mediator.Send(new GetDriverByIdQuery
        {
            Id = id
        });
        
        if (data != null)
        {
            ViewData["driver"] = data;
        }

        return Json(data);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> Create(DriverViewModel viewModel)
    {
        var data = await _mediator.Send(new CreateDriverCommand
        {
            FullName = viewModel.DriverDto.FullName,
            BirthDate = viewModel.DriverDto.BirthDate
        });

        return RedirectToAction("Index");
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> Update(DriverViewModel viewModel)
    {
        var data = await _mediator.Send(new UpdateDriverCommand
        {
            DriverId = viewModel.DriverDto.Id,
            DriverDto = viewModel.DriverDto
        });
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Driver Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> Delete(Guid id)
    {
        var data = await _mediator.Send(new DeleteDriverCommand
        {
            DriverId = id
        });
        
        return RedirectToAction("Index");
    }
    
    /// <summary>
    /// Driver cars
    /// </summary>
    /// <param name="driverId"></param>
    /// <returns></returns>
    public async Task<IActionResult> Cars(Guid driverId)
    {
        var data = await _mediator.Send(new GetCarsByDriverIdQuery
        {
            DriverId = driverId
        });

        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }
        
        return View();
    }
}