using CarSales.Application.Common.Interfaces;
using CarSales.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarSales.Infrastructure.Persistence.EF.Context;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<CarEntity> Cars => Set<CarEntity>();

    public DbSet<PriceEntity> Prices => Set<PriceEntity>();

    public DbSet<BookingEntity> Bookings => Set<BookingEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<BookingEntity>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<CarEntity>().HasQueryFilter(f => !f.IsDeleted);
        modelBuilder.Entity<PriceEntity>().HasQueryFilter(f => !f.IsDeleted);
    }


}


