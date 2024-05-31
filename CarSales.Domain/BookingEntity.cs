using CarSales.Domain.Base;

namespace CarSales.Domain;

public class BookingEntity : EntityBase
{
    public Guid CarId { get; set; }

    public string Model { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTimeOffset BookingStartDate { get; set; }

    public DateTimeOffset BookingEndDate { get; set; }

    public CarEntity Car { get; set; } = null!;
}