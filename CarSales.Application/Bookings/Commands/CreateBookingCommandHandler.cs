using AutoMapper;
using CarSales.Application.Common.Interfaces;
using CarSales.Application.Models;
using CarSales.Common.Errors;
using CarSales.Domain.Entities;
using CarSales.Domain.Entities.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Application.Bookings.Commands;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Result<BookingDTO>>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;
    private readonly TimeSpan _allowedBookingPeriod = new (10, 0, 0, 0);

    public CreateBookingCommandHandler(IAppDbContext context, IMapper mapper, IHttpContextAccessor httpcontextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<BookingDTO>> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {

        if (request.BookingPeriod > _allowedBookingPeriod)
        {
            return Result.Failure<BookingDTO>(
                Error.Validation("Booking.Validation", "Car booking period should be less than 10 days"));
        }

        var priceEntity = await _context.Prices.FindAsync(request.PriceId);

        if (priceEntity is null)
        {
            return Result.Failure<BookingDTO>(
                PriceErrors.NotFound(request.PriceId));
        }

        var existingBooking = await _context.Bookings.FirstOrDefaultAsync(b => b.PriceId == request.PriceId);

        if(existingBooking is not null)
        {
            return Result.Failure<BookingDTO>(
                BookingErrors.Conflict(request.PriceId));
        }

        var bookingEntity = new BookingEntity
        {
            PriceId = request.PriceId,
            BookingStartDate = DateTimeOffset.UtcNow,
            BookingEndDate = DateTimeOffset.UtcNow.Add(request.BookingPeriod),
            Price = priceEntity,
            Username = request.UserName!,
        };
        _context.Bookings.Add(bookingEntity);

        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<BookingDTO>(bookingEntity);
    }
}
