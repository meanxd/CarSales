using CarSales.Application.Prices;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CarSales.Application.Prices.Queries;
using CarSales.Application.Models;
using CarSales.WebApi.Extensions;

namespace CarSales.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PricesController : ControllerBase
{
    private readonly ISender _sender;

    public PricesController (ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("Available")]
    public async Task<IResult> GetAvailablePrices(DateTimeOffset checkDate)
    {
        Result<List<PriceDTO>> result = await _sender.Send(
            new GetAvailablePricesQuery(checkDate));

        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }
}
