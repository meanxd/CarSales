namespace CarSales.Domain.Base;

public interface CarEntity<TKey>
    where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }

    DateTimeOffset CreatedDateTime { get; set; }

    DateTimeOffset UpdatedDateTime { get; set; }

    public DateTimeOffset? DeletedDateTime { get; set; }

    bool IsDeleted { get; set; }
}