namespace CarSales.Domain.Entities.Base;

public class AuditableEntityBase : EntityBase
{
    public string ModifiedBy { get; set; } = string.Empty;

    public DateTimeOffset UpdatedDateTime { get; set; }

    public DateTimeOffset? DeletedDateTime { get; set; }
}