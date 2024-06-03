using CarSales.Domain.Entities.Base;

namespace CarSales.Domain.Entities;

public class BookingEntity : AuditableEntityBase
{
    public Guid PriceId { get; set; }

    public DateTimeOffset BookingStartDate { get; set; }

    public DateTimeOffset BookingEndDate { get; set; }

    public PriceEntity Price { get; set; } = null!;

    public string Username { get; set; } = string.Empty;
}