using CarSales.Common.Errors;

namespace CarSales.Domain.Entities.Errors;

public static class BookingErrors
{
    public static Error Conflict(Guid PriceId) => Error.Conflict(
        "Booking.Conflict", $"The Pricing with Id = {PriceId} is already booked.");
}
