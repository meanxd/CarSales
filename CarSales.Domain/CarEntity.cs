using CarSales.Domain.Base;

namespace CarSales.Domain;

public class CarEntity : EntityBase
{
    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;
}