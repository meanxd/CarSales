using CarSales.Application.Bookings;
using CarSales.Application.Bookings.Commands;
using CarSales.Application.Models;
using CarSales.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarSales.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class BookingsController : ControllerBase
{
    private readonly IHttpContextAccessor _httpcontextAccessor;
    private readonly ISender _sender;

    public BookingsController(IHttpContextAccessor httpContextAccessor, ISender sender)
    {
        _httpcontextAccessor = httpContextAccessor; 
        _sender = sender;
    }
    [HttpPost("Book")]
    [Authorize]
    public async Task<IResult> CreateBooking(Guid priceId, TimeSpan bookingPeriod)
    {
        Result<BookingDTO> result = await _sender.Send(
            new CreateBookingCommand(
                priceId,
                bookingPeriod,
                _httpcontextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name)));

        return result.IsSuccess ? Results.Ok(result.Value) : result.ToProblemDetails();
    }
}
