using MediatR;
using CarSales.Application.Models;

namespace CarSales.Application.Prices.Queries;

public record GetAvailablePricesQuery(DateTimeOffset CheckDate)
    : IRequest<Result<List<PriceDTO>>>;
