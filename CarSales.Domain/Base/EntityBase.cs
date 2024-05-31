namespace CarSales.Domain.Base;

public abstract class EntityBase : CarEntity<Guid>
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset UpdatedDateTime { get; set; }
    public DateTimeOffset? DeletedDateTime { get; set; }
    public bool IsDeleted { get; set; }
}