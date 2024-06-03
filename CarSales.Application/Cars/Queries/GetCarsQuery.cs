using CarSales.Application.Cars;
using CarSales.Application.Models;
using MediatR;

namespace CarSales.Application.Bookings.Commands;

public record GetCarsQuery()
    : IRequest<Result<List<CarDTO>>>;
