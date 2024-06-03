using AutoMapper;
using CarSales.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CarSales.Application.Models;
using AutoMapper.QueryableExtensions;

namespace CarSales.Application.Prices.Queries;

public class GetAvailablePricesQueryHandler : IRequestHandler<GetAvailablePricesQuery, Result<List<PriceDTO>>>
{
    private readonly IMapper _mapper;
    private readonly IAppDbContext _context;

    public GetAvailablePricesQueryHandler(IAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Result<List<PriceDTO>>> Handle(GetAvailablePricesQuery request, CancellationToken cancellationToken)
    {
        var availablePrices = await _context.Prices
            .Where(p => !_context.Bookings.Any(b => 
                    b.PriceId == p.Id &&
                    (request.CheckDate <= p.EndDate || p.EndDate == null) &&
                    request.CheckDate >= p.StartDate))
            .ProjectTo<PriceDTO>(_mapper.ConfigurationProvider)
            .ToListAsync();

        return availablePrices;

    }
}
