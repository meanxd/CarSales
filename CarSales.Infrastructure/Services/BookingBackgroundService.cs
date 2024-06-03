using CarSales.Infrastructure.Persistence.EF.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarSales.Infrastructure.Services;

public class BookingBackgroundService : IHostedService, IDisposable
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public BookingBackgroundService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var timer = new Timer(CheckAndDeleteExpiredBookings, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));
        return Task.CompletedTask;
    }

    private void CheckAndDeleteExpiredBookings(object? state)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var now = DateTime.UtcNow;
            var expiredBookings = _context.Bookings.Where(b => b.IsDeleted == false && b.BookingEndDate < now);

            foreach (var booking in expiredBookings)
            {
                booking.IsDeleted = true;
            }

            _context.SaveChanges();
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public void Dispose()
    {
    }
}