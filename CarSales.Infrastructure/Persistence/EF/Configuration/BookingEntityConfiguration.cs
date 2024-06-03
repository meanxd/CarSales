using CarSales.Domain.Entities;
using CarSales.Infrastructure.Persistence.EF.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.Persistence.EF.Configuration;

internal sealed class BookingEntityConfigurationn : AuditableEntityConfigurationBase<BookingEntity>
{
    private const string TableName = "Bookings";

    protected override void ConfigureInternal(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable(TableName);

        builder.Property(x => x.PriceId).IsRequired(); ;
        builder.Property(x => x.BookingStartDate).IsRequired();
        builder.Property(x => x.BookingEndDate).IsRequired();

        builder.HasOne(b => b.Price)
            .WithMany()
            .HasForeignKey(b => b.PriceId)
            .IsRequired();

        builder.HasIndex(b => b.PriceId)
           .HasFilter("NOT (\"IsDeleted\")")
           .IsUnique();

    }
}
