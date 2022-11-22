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
    public async Task<IActionResult> CreateDriver(DriverViewModel viewModel)
    {
        await _mediator.Send(new CreateDriverCommand
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
    public async Task<IActionResult> UpdateDriver(DriverViewModel viewModel)
    {
        await _mediator.Send(new UpdateDriverCommand
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
    public async Task<IActionResult> DeleteDriver(Guid id)
    {
        await _mediator.Send(new DeleteDriverCommand
        {
            DriverId = id
        });
        
        return RedirectToAction("Index");
    }
    
    // -------------------------------------------
    // Car
    // -------------------------------------------
    
    /// <summary>
    /// Cars
    /// </summary>
    /// <param name="driverId"> Driver id </param>
    /// <returns> View </returns>
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
    

    /// <summary>
    /// Get car by Id
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Car entity </returns>
    public async Task<IActionResult> GetCarById(Guid id)
    {
        var data = await _mediator.Send(new GetCarByIdQuery
        {
            Id = id
        });
        
        if (data != null)
        {
            ViewData["car"] = data;
        }

        return Json(data);
    }

    /// <summary>
    /// Create
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> CreateCar(DriverViewModel viewModel)
    {
        await _mediator.Send(new CreateCarCommand
        {
            Number = viewModel.CarDto.Number,
            Color = viewModel.CarDto.Color,
            Model = viewModel.CarDto.Model
        });

        return RedirectToAction("Cars");
    }

    /// <summary>
    /// Update
    /// </summary>
    /// <param name="viewModel"> Driver view model </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> UpdateCar(DriverViewModel viewModel)
    {
        await _mediator.Send(new UpdateCarCommand
        {
            CarId = viewModel.CarDto.Id,
            CarDto = viewModel.CarDto
        });
        
        return RedirectToAction("Cars");
    }

    /// <summary>
    /// Delete
    /// </summary>
    /// <param name="id"> Car Id </param>
    /// <returns> Redirect to index page </returns>
    public async Task<IActionResult> DeleteCar(Guid id)
    {
        var data = await _mediator.Send(new DeleteCarCommand
        {
            CarId = id
        });
        
        return RedirectToAction("Cars");
    }
}