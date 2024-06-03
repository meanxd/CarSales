using CarSales.Application.Models;
using MediatR;

namespace CarSales.Application.Bookings.Commands;

public record CreateBookingCommand(Guid PriceId, TimeSpan BookingPeriod, string? UserName)
    : IRequest<Result<BookingDTO>>;
