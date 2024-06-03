using CarSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarSales.Application.Common.Interfaces;

public interface IAppDbContext
{
    public DbSet<CarEntity> Cars { get; }

    public DbSet<PriceEntity> Prices { get; }

    public DbSet<BookingEntity> Bookings { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
