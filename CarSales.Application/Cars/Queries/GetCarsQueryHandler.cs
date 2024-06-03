using AutoMapper;
using CarSales.Application.Cars;
using CarSales.Application.Common.Interfaces;
using CarSales.Application.Models;
using CarSales.Common;
using CarSales.Domain.Entities;
using CarSales.Domain.Entities.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Application.Bookings.Commands;

public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, Result<List<CarDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public GetCarsQueryHandler(IAppDbContext context, IMapper mapper, IHttpContextAccessor httpcontextAccessor)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<List<CarDTO>>> Handle(GetCarsQuery request, CancellationToken cancellationToken)
    {
        return await _mapper.ProjectTo<CarDTO>(_context.Cars).ToListAsync();
    }
}
