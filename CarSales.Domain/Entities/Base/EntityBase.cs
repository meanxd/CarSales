namespace CarSales.Domain.Entities.Base;

public abstract class EntityBase : IEntity<Guid>
{
    public Guid Id { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; }

    public bool IsDeleted { get; set; }
}