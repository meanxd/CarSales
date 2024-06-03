using CarSales.Domain.Entities.Base;

namespace CarSales.Domain.Entities;

public class CarEntity : AuditableEntityBase
{
    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;
}