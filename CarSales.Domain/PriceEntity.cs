using CarSales.Domain.Base;

namespace CarSales.Domain;

public class PriceEntity : EntityBase
{
    public Guid CarId { get; set; }

    public string Model { get; set; } = null!;

    public decimal Price { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }

    public CarEntity Car { get; set; } = null!;
}