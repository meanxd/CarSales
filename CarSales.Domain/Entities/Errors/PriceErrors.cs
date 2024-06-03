using CarSales.Common.Errors;

namespace CarSales.Domain.Entities.Errors;

public static class PriceErrors
{
    public static Error NotFound(Guid PriceId) => Error.NotFound(
        "Price.NotFound", $"The Price with Id = {PriceId} was not found.");
}
