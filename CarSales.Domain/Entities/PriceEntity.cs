using CarSales.Domain.Entities.Base;

namespace CarSales.Domain.Entities;

public class PriceEntity : AuditableEntityBase
{
    public Guid CarId { get; set; }

    public decimal Price { get; set; }

    public DateTimeOffset StartDate { get; set; }

    public DateTimeOffset? EndDate { get; set; }


    public CarEntity Car { get; set; } = null!;
}