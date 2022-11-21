using Driver.App.Commands;
using Driver.App.Queries;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

/// <summary>
/// 
/// </summary>
public class DriverController : Controller
{
    private readonly IMediator _mediator;

    public DriverController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        var data = await _mediator.Send(new GetDriversQuery());
        
        if (data.Any())
        {
            ViewData["data"] = data.ToList();
        }
        
        return View(new DriverDto());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<IActionResult> Create(DriverDto dto)
    {
        var data = await _mediator.Send(new CreateDriverCommand
        {
            FullName = dto.FullName,
            BirthDate = dto.BirthDate
        });

        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    public async Task<IActionResult> Update(DriverDto dto)
    {
        var data = await _mediator.Send(new UpdateDriverCommand
        {
            CarId = dto.Id,
            DriverDto = dto
        });
        
        return RedirectToAction("Index");
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(Guid id)
    {
        var data = await _mediator.Send(new DeleteDriverCommand
        {
            DriverId = id
        });
        
        return RedirectToAction("Index");
    }
}