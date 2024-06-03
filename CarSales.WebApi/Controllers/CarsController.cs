using CarSales.Application.Bookings.Commands;
using CarSales.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarSales.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarsController : ControllerBase
{
    private readonly ISender _sender;

    public CarsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IResult> GetCars()
    {
        var result = await _sender.Send(new GetCarsQuery());
        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }
}
