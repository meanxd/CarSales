using CarSales.Domain.Entities;
using CarSales.Infrastructure.Persistence.EF.Configuration.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSales.Infrastructure.Persistence.EF.Configuration;

internal sealed class PriceEntityConfigurationn : AuditableEntityConfigurationBase<PriceEntity>
{
    private const string TableName = "Prices";

    protected override void ConfigureInternal(EntityTypeBuilder<PriceEntity> builder)
    {
        builder.ToTable(TableName);

        builder.Property(x => x.CarId).IsRequired();
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.StartDate).IsRequired();

        builder.HasOne(b => b.Car)
            .WithMany()
            .HasForeignKey(b => b.CarId)
            .IsRequired();
    }
}
