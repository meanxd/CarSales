namespace CarSales.Domain.Entities.Base;

public interface IEntity<TKey>
    where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }

    DateTimeOffset CreatedDateTime { get; set; }

    bool IsDeleted { get; set; }
}